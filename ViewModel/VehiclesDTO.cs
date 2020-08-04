using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using MongoDB.Bson.Serialization.Attributes;

namespace ViewModel
{
    public class VehiclesDTO
    {
        [BsonId]
        public string VehiclesId { get; set; }
        public string TypeVhicles { get; set; }
        public int AmountPlaces { get; set; }
        public int PriceForKM { get; set; }

        public static VehiclesDTO ConvertToVehiclesDTO(Vehicles v)
            {
                return new VehiclesDTO()
                {
                    VehiclesId = v.VehiclesId,
                    TypeVhicles = v.TypeVhicles,
                    AmountPlaces = v.AmountPlaces.Value,
                    PriceForKM = v.PriceForKM.Value
                };
            }
            public static List<VehiclesDTO> ConvertToVehiclesDTOList(List<Vehicles> vl)
            {
                var DTOList = from v in vl
                              select new VehiclesDTO()
                              {
                                  VehiclesId = v.VehiclesId,
                                  TypeVhicles = v.TypeVhicles,
                                  AmountPlaces = v.AmountPlaces.Value,
                                  PriceForKM = v.PriceForKM.Value
                              };
                return DTOList.ToList();
            }
            public static Vehicles ConvertToVehicles(VehiclesDTO v)
            {
                return new Vehicles()
                {
                    VehiclesId = v.VehiclesId,
                    TypeVhicles = v.TypeVhicles,
                    AmountPlaces = v.AmountPlaces,
                    PriceForKM = v.PriceForKM
                };
            }
            public static List<Vehicles> ConvertTovehiclesList(List<VehiclesDTO> vl)
            {
                var VehiclesList = from v in vl
                                   select new Vehicles()
                                   {
                                       VehiclesId = v.VehiclesId,
                                       TypeVhicles = v.TypeVhicles,
                                       AmountPlaces = v.AmountPlaces,
                                       PriceForKM = v.PriceForKM
                                   };
                return VehiclesList.ToList();
            }
    }
}


