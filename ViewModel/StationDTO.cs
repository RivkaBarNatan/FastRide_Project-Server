using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using MongoDB.Bson.Serialization.Attributes;

namespace ViewModel
{
    public class StationDTO
    {
        [BsonId]
        public string StationId { get; set; }
        public string Address { get; set; }

        public static StationDTO ConvertToStationsDTO(Station s)
        {
            return new StationDTO()
            {
                StationId = s.StationId,
                Address = s.Address,

            };
        }

        public static List<StationDTO> ConvertToStationsDTOList(List<Station> sList)
        {
            var ListDTO = from s in sList
                          select new StationDTO()
                          {
                              StationId = s.StationId,
                              Address = s.Address,
                          };
            return ListDTO.ToList();

        }

        public static Station ConvertToStations(StationDTO s)
        {
            return new Station()
            {
                StationId = s.StationId,
                Address = s.Address,
            };
        }

        public static List<Station> ConvertToStationsList(List<StationDTO> sList)
        {
            var List = from s in sList
                       select new Station()
                       {
                           StationId = s.StationId,
                           Address = s.Address,
                       };
            return List.ToList();
        }
    }
}
