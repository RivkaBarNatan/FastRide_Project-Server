using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using MongoDB.Bson.Serialization.Attributes;

namespace ViewModel
{
    public class FrequencyDTO
    {
        [BsonId]
        public string FrequencyId { get; set; }
        public string FrequencyType { get; set; }
    }
}

