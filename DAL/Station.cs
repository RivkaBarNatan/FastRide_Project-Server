using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace DAL
{
    public class Station
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string StationId { get; set; }
        public string Address { get; set; }
        public int OridinalNumber { get; set; }
        public List<string> Users { get; set; }
    }
}
