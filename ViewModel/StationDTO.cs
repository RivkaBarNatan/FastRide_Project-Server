using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using MongoDB.Bson.Serialization.Attributes;

namespace ViewModel
{
    public class StationDTO
    {
        [BsonId]
        public string StationId { get; set; }
        public string Address { get; set; }
    }
}
