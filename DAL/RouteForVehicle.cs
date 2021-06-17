using DAL;
using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DAL
{
    public class RouteForVehicle
    {
        public string Vehicle { get; set; }
        public int TODOLen { get; set; }
        public string Duration { get; set; }
        public List<Station> Stations { get; set; }
    }
}
