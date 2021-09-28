using Exercise.Data;
using Exercise.Domain;
using MongoDB.Driver;
using NUnit.Framework;
using System.Collections.Generic;

namespace MongoSuperHero.Test
{
    public class Tests
    {

        private SuperHeroDbContext context;

        private const string MongoDbConnectionUrl = "mongodb://localhost:27017";
        private const string SuperHeroTestDbName = "MongoSuperHeroTest";

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var client = new MongoClient(MongoDbConnectionUrl);
            client.DropDatabase(SuperHeroTestDbName);
            var database = client.GetDatabase(SuperHeroTestDbName);
            context = new SuperHeroDbContext(database);
            MongoMethods.Init(context);
        }

        [SetUp]
        public void Setup()
        {
            context.ClearDataBase();
        }

        [Test]
        public void Test_AddOneSuperHeroTwice()
        {
            var superHeroNames = new[] { "Spiderman", "Batman" };
            foreach(var superHeroName in superHeroNames)
            {
                MongoMethods.AddOneSuperHero(superHeroName);
            }

            List<string> result = MongoMethods.GetAllSuperHeroNames();
            CollectionAssert.AreEquivalent(superHeroNames, result);

        }

        [Test]
        public void Test_AddOneSuperHeroWithRealIdentity()
        {
            var superHeroName = "Superman";
            var superHeroHariStyle = HairStyle.Radiant;
            var superHero = new SuperHero()
            {
                Name = superHeroName,
                Hair = superHeroHariStyle
            };

            var superHeroId = superHero.Id;
            var realName = "Clark Kent";

            MongoMethods.AddOneSuperHero(superHero);
            MongoMethods.UpdateSuperHeroSetRealIdentity(superHeroId, realName);

            SuperHero resultSuperHero = MongoMethods.GetSuperHero(superHeroId);

            Assert.NotNull(resultSuperHero);
            Assert.AreEqual(superHeroName, resultSuperHero.Name);
            Assert.AreEqual(superHeroHariStyle, resultSuperHero.Hair);
            Assert.AreEqual(superHeroId, resultSuperHero.Id);

            Assert.NotNull(resultSuperHero.RealIdentity);
            Assert.AreEqual(realName, resultSuperHero.RealIdentity.RealName);
            Assert.AreEqual(superHeroId, resultSuperHero.RealIdentity.HeroId);
        }
    }
}