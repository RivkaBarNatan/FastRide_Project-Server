using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using MongoDB.Bson.Serialization.Attributes;

namespace ViewModel
{
    public class VehiclesDTO
    {
        [BsonId]
        public string VehiclesId { get; set; }
        public string TypeVhicles { get; set; }
        public int AmountPlaces { get; set; }
        public int PriceForKM { get; set; }
    }
}


