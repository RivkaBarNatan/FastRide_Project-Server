using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using Dal;
using MongoDB.Driver;

namespace BL
{
    public class StationService
    {
        private readonly IMongoCollection<Station> stations;
        public StationService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            stations = database.GetCollection<Station>(this.GetType().Name);
        }
        public  List<StationDTO> GetAllStationsList()
        {
            return StationDTO.ConvertToStationsDTOList(stations.Find(_=>true).ToList());
        }

        public  StationDTO GetStationsById(string id)
        {
            return StationDTO.ConvertToStationsDTO(stations.Find(s=>s.StationId==id).ToList().FirstOrDefault());
        }

        public  void AddStationToList(StationDTO stations)
        {
            this.stations.InsertOne(StationDTO.ConvertToStations(stations));
            //TODO TE.SaveChanges();
        }

        public  void PutStations(StationDTO station)
        {
            var update = Builders<Station>.Update.Set(s => s.Address, station.Address);
            stations.UpdateOne(f => f.StationId == station.StationId, update);
            

            //TODO TE.SaveChanges();
        }

        public  void DeleteStations(string id)
        {
            stations.DeleteOne(s => s.StationId == id);
            //TODO TE.SaveChanges();
        }
    }
}


