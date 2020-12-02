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
        public string Description { get; set; }
        public List<string> Travels { get; set; }
        public List<UsersAddress> UsersAndAddress { get; set; }
        public List<string> WaitingList { get; set; }
        public string Address { get; set; }
        public Schedules Schedules { get; set; }
    }
}
