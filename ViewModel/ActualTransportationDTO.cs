using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using MongoDB.Bson.Serialization.Attributes;

namespace ViewModel
{
    public class ActualTransportationDTO
    {
        [BsonId]
        public string ActualTransportationId { get; set; }
        public DateTime Date { get; set; }
        public string TransportationId { get; set; }
        public string Performed { get; set; }

        public static ActualTransportationDTO ConvertToActualTransportationDTO(ActualTransportation a)
        {
            return new ActualTransportationDTO()
            {
                ActualTransportationId = a.ActualTransportationId,
                Date = a.Date.Value,
                TransportationId = a.TransportationId,
                Performed = a.Performed
            };
        }
        public static List<ActualTransportationDTO> ConvertToActualTransportationDTOList(List<ActualTransportation> al)
        {
            var DTOList = from a in al
                          select new ActualTransportationDTO()
                          {
                              ActualTransportationId = a.ActualTransportationId,
                              Date = a.Date.Value,
                              TransportationId = a.TransportationId,
                              Performed = a.Performed
                          };
            return DTOList.ToList();
        }
        public static ActualTransportation ConvertToActualTransportation(ActualTransportationDTO a)
        {
            return new ActualTransportation()
            {
                ActualTransportationId = a.ActualTransportationId,
                Date = a.Date,
                TransportationId = a.TransportationId,
                Performed = a.Performed
            };
        }
        public static List<ActualTransportation> ConvertToActualTransportationList(List<ActualTransportationDTO> al)
        {
            var ActualTransportationList = from a in al
                               select new ActualTransportation()
                               {
                                   ActualTransportationId = a.ActualTransportationId,
                                   Date = a.Date,
                                   TransportationId = a.TransportationId,
                                   Performed = a.Performed
                               };
            return ActualTransportationList.ToList();
        }
    }
}

