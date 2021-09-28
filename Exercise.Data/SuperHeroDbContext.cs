using Exercise.Domain;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Exercise.Data
{
    public class SuperHeroDbContext
    {
        private const string MongoDbUrl = "mongodb://localhost:27017";
        private const string SuperHeroName = "MongoSuperHero";
        private const string SuperHeroCollectionName = "superheroes";
        private const string QuoteCollectionName = "quotes";
        private const string RealIdentityCollectionName = "real_identities";
        private const string SuperheroBattlesCollectionName = "superhero_battles";
        private const string BattleLogsCollectionName = "battle_logs";



        private readonly IMongoDatabase database;


        public SuperHeroDbContext(IMongoDatabase database)
        {
            //var client = new MongoClient(MongoDbUrl);
            //database = client.GetDatabase(SuperHeroName);
            this.database = database;
        }

        public void ClearDataBase()
        {
            foreach(var collectionName in collectionNames)
            {
                database.DropCollection(collectionName.Value);
            }
        }

        private IMongoCollection<T> GetCollection<T>()
        {
            var typeOfInstance = typeof(T);
            var collectionName = collectionNames[typeOfInstance];
            return database.GetCollection<T>(collectionName);
        }

        private readonly Dictionary<Type, string> collectionNames = new()
        {
            { typeof(SuperHero), SuperHeroCollectionName },
            { typeof(Quote), QuoteCollectionName},
            { typeof(RealIdentity), RealIdentityCollectionName},
            { typeof(SuperHeroBattle), SuperheroBattlesCollectionName},
            { typeof(BattleLog), BattleLogsCollectionName},
        };

        public IMongoCollection<SuperHero> SuperHeroes => GetCollection<SuperHero>();
        public IMongoCollection<Quote> Quotes => GetCollection<Quote>();
        public IMongoCollection<RealIdentity> RealIdentities => GetCollection<RealIdentity>();
        public IMongoCollection<SuperHeroBattle> SuperHeroBattles => GetCollection<SuperHeroBattle>();

        public IMongoCollection<BattleLog> BattleLogs => GetCollection<BattleLog>();






    }
}
