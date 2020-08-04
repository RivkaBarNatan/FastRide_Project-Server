using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using MongoDB.Bson.Serialization.Attributes;

namespace ViewModel
{
    public class TransportationDTO
    {
        [BsonId]
        public string TransportationId { get; set; }
        public TimeSpan StartTime { get; set; }
        public string SourceAddress { get; set; }
        public int Price { get; set; }
        public string VehicleId { get; set; }

        public static TransportationDTO ConvertToTransportationDTO(Transportation t)
        {
            return new TransportationDTO()
            {
                TransportationId=t.TransportationId,
                StartTime=t.StartTime.Value,
                SourceAddress=t.SourceAddress,
                Price=t.Price.Value,
                VehicleId=t.VehicleId

            };
        }
        public static List<TransportationDTO> ConvertToTransportationDTOList(List<Transportation> tl)
        {
            var DTOList = from t in tl
                          select new TransportationDTO()
                          {
                              TransportationId = t.TransportationId,
                              StartTime = t.StartTime.Value,
                              SourceAddress = t.SourceAddress,
                              Price = t.Price.Value,
                              VehicleId = t.VehicleId
                          };
            return DTOList.ToList();
        }
        public static Transportation ConvertToTransportation(TransportationDTO t)
        {
            return new Transportation()
            {
                TransportationId = t.TransportationId,
                StartTime = t.StartTime,
                SourceAddress = t.SourceAddress,
                Price = t.Price,
                VehicleId = t.VehicleId
            };
        }
        public static List<Transportation> ConvertToTransportationList(List<TransportationDTO> tl)
        {
            var ChildInFamilyList = from t in tl
                                    select new Transportation()
                                    {
                                        TransportationId = t.TransportationId,
                                        StartTime = t.StartTime,
                                        SourceAddress = t.SourceAddress,
                                        Price = t.Price,
                                        VehicleId = t.VehicleId
                                    };
            return ChildInFamilyList.ToList();
        }

    }
}
