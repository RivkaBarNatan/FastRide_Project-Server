using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using DAL;
using MongoDB.Driver;
using AutoMapper;

namespace BL
{
    public class StationService
    {
        private readonly IMongoCollection<Station> stations;
        private readonly IMapper mapper;
        public StationService(IDatabaseSettings settings, IMapper map)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            stations = database.GetCollection<Station>(this.GetType().Name);

            mapper = map;
        }
        public  List<StationDTO> GetAllStationsList()
        {
            return mapper.Map<List<StationDTO>>(stations.Find(_=>true).ToList());
        }

        public  StationDTO GetStationsById(string id)
        {
            return mapper.Map<StationDTO>(stations.Find(s=>s.StationId==id).ToList().FirstOrDefault());
        }

        public  void AddStationToList(StationDTO stations)
        {
            this.stations.InsertOne(mapper.Map<Station>(stations));
            //TODO TE.SaveChanges();
        }

        public  void PutStations(StationDTO station)
        {
            var update = Builders<Station>.Update.Set(s => s.Address, station.Address);
            stations.UpdateOne(f => f.StationId == station.StationId, update);
        }

        public  void DeleteStations(string id)
        {
            stations.DeleteOne(s => s.StationId == id);
        }
    }
}


