using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Domain
{
    public enum QuoteStyle
    {
        Lame,
        Cheesy,
        Awesome
    }
    public class Quote : MongoBase
    {
        [BsonElement("text")]
        public string Text { get; set; }
        
        [BsonElement("style")]
        [BsonRepresentation(BsonType.String)]
        public QuoteStyle? Style { get; set; }

        [BsonElement("style")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string HeroId { get; set; }
    }
}
