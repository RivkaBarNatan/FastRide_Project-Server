using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using MongoDB.Bson.Serialization.Attributes;

namespace ViewModel
{
    public class TransportationDTO
    {
        [BsonId]
        public string TransportationId { get; set; }
        public List<string> Travels { get; set; }
        public List<string> Users { get; set; }
        public string Address { get; set; }
        public Schedules Schedules { get; set; }
    }
}
