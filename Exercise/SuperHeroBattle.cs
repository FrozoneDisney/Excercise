using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Domain
{
    public class SuperHeroBattle : MongoBase
    {
        [BsonElement("superhero_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string SuperHeroId { get; set; }

        [BsonElement("battle_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string BattleId { get; set; }
    }
}
