using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Domain
{
    public class Battle : MongoBase
    {
        [BsonElement("name")]
        [BsonRepresentation(BsonType.String)]
        public string Name { get; set; }

        [BsonElement("description")]
        [BsonRepresentation(BsonType.String)]
        public string Description { get; set; }

        [BsonElement("is_brutal")]
        [BsonRepresentation(BsonType.Boolean)]
        public Boolean IsBrutal { get; set; }

        [BsonElement("start_date")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime StartDate { get; set; }

        [BsonElement("end_date")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime EndDate { get; set; }
    }
}
