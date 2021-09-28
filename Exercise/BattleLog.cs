using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Domain
{
    public class BattleLog : MongoBase
    {
        [BsonElement("battle_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string BattleId { get; set; }

        [BsonElement("name")]
        [BsonRepresentation(BsonType.String)]
        public string Name { get; set; }
    }
}
