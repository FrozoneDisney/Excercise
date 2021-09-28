using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Domain
{
    public class RealIdentity : MongoBase
    {
        [BsonElement("real_name")]
        public string RealName { get; set; }

        [BsonElement("hero_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string  HeroId { get; set; }
    }
}
