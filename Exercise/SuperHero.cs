using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Exercise.Domain
{
    public enum HairStyle
    {
        Covered,
        Radiant,
        Normal
    }
    public class SuperHero : MongoBase
    {

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("Hair")]
        [BsonRepresentation(BsonType.String)]
        public HairStyle? Hair { get; set; }

        [BsonIgnore]
        public List<Quote> Quotes { get; set; } = new();
        [BsonIgnore]
        public RealIdentity RealIdentity { get; set; }
    }

}
