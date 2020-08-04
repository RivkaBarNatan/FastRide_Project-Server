using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using ViewModel;


namespace UI
{
    public class VehiclesFunction
    {
        static TransportationDBEntities TE = new TransportationDBEntities();
        public static List<VehiclesDTO> GetAllVehiclesList()
        {
            //TODO using( TransportationDBEntities TE = new TransportationDBEntities()) 
            {
                var x = TE.Vehicles.ToList();
                return VehiclesDTO.ConvertToVehiclesDTOList(x);
            }
            
        }

        public static VehiclesDTO GetVehiclesByType(string type)
        {
            Vehicles vehicles = TE.Vehicles.Where(v => v.TypeVhicles.Equals(type)).FirstOrDefault();
            return VehiclesDTO.ConvertToVehiclesDTO(vehicles);
        }

        public static void AddVehiclesToList(VehiclesDTO vehicles)
        {
            TE.Vehicles.Add(VehiclesDTO.ConvertToVehicles(vehicles));
            //TODO TE.SaveChanges();
        }

        public static void PutVehicles(VehiclesDTO vehicle)
        {
            Vehicles vehicles = TE.Vehicles.Where(v => v.VehiclesId.Equals(vehicle.VehiclesId)).FirstOrDefault();
            vehicles.TypeVhicles = vehicle.TypeVhicles;
            vehicles.PriceForKM = vehicle.PriceForKM;
            vehicles.AmountPlaces = vehicle.AmountPlaces;
            //TODO TE.SaveChanges();
        }

        public static void DeleteVehicles(int id)
        {
            Vehicles vehicles = TE.Vehicles.Where(v => v.VehiclesId.Equals(id)).FirstOrDefault();
            TE.Vehicles.Remove(vehicles);
            //TODO TE.SaveChanges();
        }

        public static long[] GetAllVehiclesCapacity(List<VehiclesDTO> vl)
        {
            var CapacityList = from v in vl
                               select Convert.ToInt64 (v.AmountPlaces);

            return CapacityList.ToArray();
            //long[] a = { 10, 10, 10, 10 };
            //return a;
        }

    }
}
