using DAL;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel
{
    public class RouteForVehicleDTO
    {
        public string Vehicle { get; set; }
        public int TODOLen { get; set; }
        public string Duration { get; set; }
        public List<Station> Stations { get; set; }
    }
}
