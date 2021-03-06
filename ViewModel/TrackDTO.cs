using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using MongoDB.Bson.Serialization.Attributes;

namespace ViewModel
{
    public class TrackDTO
    {
        [BsonId]
        public string TrackId { get; set; }
        public string EstablishmentId { get; set; }
        public string Destination_Source { get; set; }
        public string Ingathering_Interspersion { get; set; }
        public string FrequencyId { get; set; }
        public int TrackPrice { get; set; }
    }
}
