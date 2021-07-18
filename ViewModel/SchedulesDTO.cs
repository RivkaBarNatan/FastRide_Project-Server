using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using MongoDB.Bson.Serialization.Attributes;

namespace ViewModel
{
    public class SchedulesDTO
    {
        [BsonId]
        public string ScheduleId { get; set; }
        public object Frequency { get; set; }
        public string DepartureTime { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
        public Routes Routes { get; set; }
    }
}
