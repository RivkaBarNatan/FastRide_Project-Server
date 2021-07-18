using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ViewModel;
using MongoDB.Driver;
using AutoMapper;


namespace BL
{
    public class VehiclesService
    {
        private readonly IMongoCollection<Vehicles> vehicles;
        private readonly IMapper mapper;
        public VehiclesService(IDatabaseSettings settings, IMapper map)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            vehicles = database.GetCollection<Vehicles>(this.GetType().Name);

            mapper = map;
        }
        public  List<VehiclesDTO> GetAllVehiclesList()
        {
            return mapper.Map<List<VehiclesDTO>>(vehicles.Find(_ => true).ToList());
        }

        public VehiclesDTO GetVehicleById(string id)
        {
            return mapper.Map<VehiclesDTO>(vehicles.Find(v => v.VehiclesId == id).ToList().FirstOrDefault());
        }
        public  VehiclesDTO GetVehiclesByType(string type)
        {
            return mapper.Map<VehiclesDTO>(vehicles.Find(v => v.TypeVhicles == type).ToList());
        }

        public Vehicles GetVehicleByAddressAndCapacity(string address, long capacity)
        {
            return vehicles.Find(x => x.AmountPlaces == capacity && x.DriverAddress == address).First();
        }

        public  void AddVehiclesToList(VehiclesDTO vehicles)
        {
            this.vehicles.InsertOne(mapper.Map<Vehicles>(vehicles));
        }

        public  void PutVehicles(VehiclesDTO vehicle)
        {
            vehicles.ReplaceOne(V => V.VehiclesId == vehicle.VehiclesId, mapper.Map<Vehicles>(vehicle));
        }
        public void PutVehicles(Vehicles vehicle)
        {
            vehicles.ReplaceOne(V => V.VehiclesId == vehicle.VehiclesId, vehicle);
        }

        public  void DeleteVehicles(string id)
        {
            vehicles.DeleteOne(v => v.VehiclesId == id);
        }

        public long[] GetAllVehiclesCapacity()
        {
            var vehiclelist = GetAllVehiclesList();
            var CapacityList = from v in vehiclelist
                               select Convert.ToInt64 (v.AmountPlaces);

            return CapacityList.ToArray();
            //long[] a = { 10, 10, 10, 10 };
            //return a;
        }

    }
}
