using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using  DAL;

namespace DAL
{
    
    public class Transportation
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string TransportationId { get; set; }
        public List<string> Travels { get; set; }
        public List<string> Users { get; set; }
        public string Address { get; set; }
        public Schedules Schedules { get; set; }
    }
}
