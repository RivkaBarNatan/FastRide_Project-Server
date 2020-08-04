using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using MongoDB.Bson.Serialization.Attributes;

namespace ViewModel
{
    public class PassengerInStationDTO
    {
        [BsonId]
        public string PassengerInStationId { get; set; }
        public string StationId { get; set; }
        public string PassengerId { get; set; }
        public TimeSpan Hour { get; set; }

        public static PassengerInStationDTO ConvertToPassengerInStationDTO(PassengerInStation p)
        {
            return new PassengerInStationDTO()
            {
                PassengerInStationId = p.PassengerInStationId,
                StationId =p.StationId,
                PassengerId=p.PassengerId,
                Hour=p.Hour.Value
            };
        }
        public static List<PassengerInStationDTO> ConvertToPassengerInStationDTOList(List<PassengerInStation> pl)
        {
            var DTOList = from p in pl
                          select new PassengerInStationDTO()
                          {
                              PassengerInStationId = p.PassengerInStationId,
                              StationId = p.StationId,
                              PassengerId = p.PassengerId,
                              Hour = p.Hour.Value
                          };
            return DTOList.ToList();
        }
        public static PassengerInStation ConvertToPassengerInStation(PassengerInStationDTO p)
        {
            return new PassengerInStation()
            {
                PassengerInStationId = p.PassengerInStationId,
                StationId = p.StationId,
                PassengerId = p.PassengerId,
                Hour = p.Hour
            };
        }
        public static List<PassengerInStation> ConvertToPassengerInStationList(List<PassengerInStationDTO> pl)
        {
            var ChildInFamilyList = from p in pl
                                    select new PassengerInStation()
                                    {
                                        PassengerInStationId = p.PassengerInStationId,
                                        StationId = p.StationId,
                                        PassengerId = p.PassengerId,
                                        Hour = p.Hour
                                    };
            return ChildInFamilyList.ToList();
        }
    }
}
