using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DAL
{
    public class Schedules
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string SchduleId { get; set; }
        public object Frequency { get; set; }
        public string DepartureTime { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
        public Routes Routes { get; set; }
    }
}
