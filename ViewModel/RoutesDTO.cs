using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using MongoDB.Bson.Serialization.Attributes;

namespace ViewModel
{
    public class RoutesDTO
    {
        [BsonId]
        public string RouteId { get; set; }
        public string TravelMode { get; set; }
        public bool IsDispersion { get; set; }
        public int CountUsers { get; set; }
        public List<RouteForVehicle> RouteForVehicle { get; set; }
    }
}
