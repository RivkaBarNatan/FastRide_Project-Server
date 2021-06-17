using DAL;
using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DAL
{
    public class Routes
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string RouteId { get; set; }
        public string TravelMode { get; set; }
        public bool IsDispersion { get; set; }
        public int CountUsers { get; set; }
        public List<RouteForVehicle> RouteForVehicle { get; set; }
    }
}
