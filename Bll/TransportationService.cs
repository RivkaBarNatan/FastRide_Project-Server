using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using DAL;
using MongoDB.Driver;
using AutoMapper;
using BL.OrTools;
using GoogleApi.Entities.Common;

namespace BL
{
    public class TransportationService
    {
        private readonly IMongoCollection<Transportation> transportations;
        private readonly IMongoCollection<User> user;
        private readonly VehiclesService vehicleSer;
        private readonly IMapper mapper;
        private readonly VrpCapacity vrpCapacity;

        public TransportationService(IDatabaseSettings settings, IMapper map, VehiclesService vehicleSer, VrpCapacity vrpCapacity)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            transportations = database.GetCollection<Transportation>(this.GetType().Name + "s");
            user = database.GetCollection<User>("UserService");
            mapper = map;
            this.vehicleSer = vehicleSer;
            this.vrpCapacity = vrpCapacity;
        }

        public List<TransportationDTO> GetAllTransportationsList()
        {
            
            return mapper.Map<List<TransportationDTO>>(transportations.Find(_ => true).ToList());
        }

        public TransportationDTO GetTransportationsById(string id)
        {
            return mapper.Map<TransportationDTO>(transportations.Find(t => t.TransportationId == id).ToList().FirstOrDefault());
        }

        public void AddTransportationsToList(TransportationDTO transportation)
        {
            //var ua = mapper.Map<List<UsersAddressDTO>>(transportation.UsersAndAddress);
            var ua = transportation.UsersAndAddress;
            transportation.UsersAndAddress = ua;
            transportations.InsertOne(mapper.Map<Transportation>(transportation));
        }

        public void PutTransportations(TransportationDTO transportation)
        {
            transportations.ReplaceOne(t => t.TransportationId == transportation.TransportationId, mapper.Map<Transportation>(transportation));
        }

        public void DeleteTransportations(string id)
        {
            //Transportation transportations = TE.Transportation.Where(t => t.TransportationId.Equals(id)).FirstOrDefault();
            //TE.Transportation.Remove(transportations);
            transportations.DeleteOne(t => t.TransportationId == id);
        }

        public List<string> GetAddressList(string transportationId)
        {
            var address = transportations.AsQueryable()
                .Where(t => t.TransportationId == transportationId)
                .Select(t => t.Address);
            return address.ToList();
        }
        public class AddressesAndCountPassengers
        {
            public string Address;
            public int Count;
        }
        public List<AddressesAndCountPassengers> GetCountPassengerInStation(string transportationId)
        {
            var group = transportations.AsQueryable().Where(t => t.TransportationId == transportationId).ToList();

            var a = group.SelectMany(t => t.UsersAndAddress);
            
            var b = a.GroupBy(u=> u.Address)
            .Select((t)=> new AddressesAndCountPassengers { Address = t.Key,  Count = t.Count()});
            return b.ToList();
        }

        public VrpCapacity.ToReturn CalcRoute(string transportationId)
        {
            DataModel data = new DataModel();
            var destinations = GetCountPassengerInStation(transportationId).Select(d => d.Address).ToList();
            var origion = GetTransportationsById(transportationId).Address;
            
            
            var address = new List<string>{origion };

            address.AddRange(vehicleSer.GetAllVehiclesList().Select(v => v.DriverAddress).ToList());

            address.AddRange(destinations);

            
            data.DistanceMatrix = vrpCapacity.distanceMatrix(address);

            data.VehicleCapacities = vehicleSer.GetAllVehiclesCapacity();

            data.VehicleNumber = data.VehicleCapacities.Length;


            var demands = new List<long> { 0 };
            for (int i = 0; i < data.VehicleNumber; i++)
            {
                demands.Add(0);
            }
            demands.AddRange(GetCountPassengerInStation(transportationId).Select(c => (long)c.Count));
            data.Demands = demands.ToArray();
            


            //פיזור
            if (GetTransportationsById(transportationId).Schedules.Routes.IsDispersion == true)
            {
                data.start = new int[data.VehicleNumber];
                data.start.AsSpan().Fill(0);
                data.end = new int[data.VehicleNumber];
                for (int i = 0; i < data.VehicleNumber; i++)
                {
                    data.end[i] = i+1;
                }
            }
            else
            {
                data.end = new int[data.VehicleNumber];
                data.end.AsSpan().Fill(0);
                data.start = new int[data.VehicleNumber];
                for (int i = 0; i < data.VehicleNumber; i++)
                {
                    data.start[i] = i + 1;
                }
            }

            return vrpCapacity.CalcRoute(data, address.ToArray());
        }

        public VrpCapacity.ToReturn StationUnion(List<string> route, long[]distances, string transportationId)
        {
            //Remove a station that the distance from the previous station less than 50 meters.
            var distanceDurations = vrpCapacity.distanceMatrix(route);
            for (int i = 0; i < distanceDurations.Length; i++)
            {
                if (i > route.Count()-1)
                    break;
                for (int j = 0; j < distanceDurations.Length; j++)
                {
                    if (j > route.Count()-1)
                        break;
                    if (i < j && distanceDurations[i, j].duration < 120)
                        route.Remove(route[i]);
                }
            }
            DataModel data = new DataModel();
            var destinations = route;
            var origion = GetTransportationsById(transportationId).Address;


            var address = new List<string> { origion };

            address.AddRange(vehicleSer.GetAllVehiclesList().Select(v => v.DriverAddress).ToList());

            address.AddRange(destinations);


            data.DistanceMatrix = vrpCapacity.distanceMatrix(address);

            data.VehicleCapacities = vehicleSer.GetAllVehiclesCapacity();

            data.VehicleNumber = data.VehicleCapacities.Length;


            var demands = new List<long> { 0 };
            for (int i = 0; i < data.VehicleNumber; i++)
            {
                demands.Add(0);
            }
            demands.AddRange(GetCountPassengerInStation(transportationId).Select(c => (long)c.Count));
            data.Demands = demands.ToArray();



            //פיזור
            if (GetTransportationsById(transportationId).Schedules.Routes.IsDispersion == true)
            {
                data.start = new int[data.VehicleNumber];
                data.start.AsSpan().Fill(0);
                data.end = new int[data.VehicleNumber];
                for (int i = 0; i < data.VehicleNumber; i++)
                {
                    data.end[i] = i + 1;
                }
            }
            else
            {
                data.end = new int[data.VehicleNumber];
                data.end.AsSpan().Fill(0);
                data.start = new int[data.VehicleNumber];
                for (int i = 0; i < data.VehicleNumber; i++)
                {
                    data.start[i] = i + 1;
                }
            }

            return vrpCapacity.CalcRoute(data, address.ToArray());
        }
    }
}