using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Domain
{
    public class BattleEvent : MongoBase
    {
        [BsonElement("order")] 
        public int Order { get; set; }

        [BsonElement("summary")]
        public string Summary { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("battle_events")]
        public List<BattleEvent> BattleEvents { get; set; } = new();
    }
}
