using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using MongoDB.Bson.Serialization.Attributes;

namespace ViewModel
{
    public class PassengerInTransportationDTO
    {
        [BsonId]
        public string PassengerInTransportationId { get; set; }
        public string TransportationId { get; set; }
        public string PassengerId { get; set; }

        public static PassengerInTransportationDTO ConvertToPassengerInTransportationDTO(PassengerInTransportation p)
        {
            return new PassengerInTransportationDTO()
            {
                PassengerInTransportationId=p.PassengerInTransportationId,
                PassengerId=p.PassengerId,
                TransportationId=p.TransportationId

            };
        }
        public static List<PassengerInTransportationDTO> ConvertToPassengerInTransportationDTOList(List<PassengerInTransportation> pl)
        {
            var DTOList = from p in pl
                          select new PassengerInTransportationDTO()
                          {
                              PassengerInTransportationId = p.PassengerInTransportationId,
                              PassengerId = p.PassengerId,
                              TransportationId = p.TransportationId
                          };
            return DTOList.ToList();
        }
        public static PassengerInTransportation ConvertToPassengerInTransportation(PassengerInTransportationDTO p)
        {
            return new PassengerInTransportation()
            {
                PassengerInTransportationId = p.PassengerInTransportationId,
                PassengerId = p.PassengerId,
                TransportationId = p.TransportationId
            };
        }
        public static List<PassengerInTransportation> ConvertToPassengerInTransportationList(List<PassengerInTransportationDTO> pl)
        {
            var ChildInFamilyList = from p in pl
                                    select new PassengerInTransportation()
                                    {
                                        PassengerInTransportationId = p.PassengerInTransportationId,
                                        PassengerId = p.PassengerId,
                                        TransportationId = p.TransportationId
                                    };
            return ChildInFamilyList.ToList();
        }

    }
}
