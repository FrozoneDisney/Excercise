using Exercise.Data;
using Exercise.Domain;
using MongoDB.Driver;
using System;

namespace Exercise.App
{
    class Program
    {
        private const string MongoDbConnectionUrl = "mongodb://localhost:27017";
        private const string SuperHeroDbName = "MongoSuperHero";
        static void Main(string[] args)
        {
            var client = new MongoClient(MongoDbConnectionUrl);
            var database = client.GetDatabase(SuperHeroDbName);
            var dbContext = new SuperHeroDbContext(database);
            //var dbContext = new SuperHeroDbContext();

            var superHeroesCollection = dbContext.SuperHeroes;

            var hulk = new SuperHero { Name = "Hulk" };
            superHeroesCollection.InsertOne(hulk);

            var filter = FilterDefinition<SuperHero>.Empty;
            var allHeroes = superHeroesCollection.Find(filter).ToList();
            foreach(var hero in allHeroes)
            {
                Console.WriteLine($"{hero.Name} answered the call");
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
