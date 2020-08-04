using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using ViewModel;
using MongoDB.Driver;


namespace BL
{
    public class VehiclesService
    {
        private readonly IMongoCollection<Vehicles> vehicles;
        public VehiclesService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            vehicles = database.GetCollection<Vehicles>(this.GetType().Name);
        }
        public  List<VehiclesDTO> GetAllVehiclesList()
        {
                return VehiclesDTO.ConvertToVehiclesDTOList(vehicles.Find(_ => true).ToList());
        }

        public  VehiclesDTO GetVehiclesByType(string type)
        {
            return VehiclesDTO.ConvertToVehiclesDTO(vehicles.Find(v => v.TypeVhicles == type).ToList().FirstOrDefault());
        }

        public  void AddVehiclesToList(VehiclesDTO vehicles)
        {
            this.vehicles.InsertOne(VehiclesDTO.ConvertToVehicles(vehicles));
            //TODO TE.SaveChanges();
        }

        public  void PutVehicles(VehiclesDTO vehicle)
        {
            vehicles.ReplaceOne(V => V.VehiclesId == vehicle.VehiclesId, VehiclesDTO.ConvertToVehicles(vehicle));
            //TODO TE.SaveChanges();
        }

        public  void DeleteVehicles(string id)
        {
            vehicles.DeleteOne(v => v.VehiclesId == id);
            //TODO TE.SaveChanges();
        }

        public  long[] GetAllVehiclesCapacity(List<VehiclesDTO> vl)
        {
            var CapacityList = from v in vl
                               select Convert.ToInt64 (v.AmountPlaces);

            return CapacityList.ToArray();
            //long[] a = { 10, 10, 10, 10 };
            //return a;
        }

    }
}
