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
    public class PassengerInStationService
    {
        private readonly IMongoCollection<PassengerInStation> passengerInStation;
        public PassengerInStationService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            passengerInStation = database.GetCollection<PassengerInStation>(this.GetType().Name);
        }
        public  List<PassengerInStationDTO> GetAllPassengerInStationList()
        {
            return PassengerInStationDTO.ConvertToPassengerInStationDTOList(passengerInStation.Find(_=>true).ToList());
        }

        public  PassengerInStationDTO GetPassengerInStationById(string id)
        {
            return PassengerInStationDTO.ConvertToPassengerInStationDTO(passengerInStation.Find(p=>p.PassengerInStationId==id).ToList().FirstOrDefault());
        }

        public  void AddPassengerInStationToList(PassengerInStationDTO passengerInStation)
        {
            this.passengerInStation.InsertOne(PassengerInStationDTO.ConvertToPassengerInStation(passengerInStation));
            //TODO TE.SaveChanges();
        }

        public  void PutPassengerInStation(PassengerInStationDTO passengerInStat)
        {

            passengerInStation.ReplaceOne(p => p.PassengerInStationId == passengerInStat.PassengerInStationId, PassengerInStationDTO.ConvertToPassengerInStation(passengerInStat));
        }

        public  void DeletePassengerInStation(string id)
        {
            passengerInStation.DeleteOne(p => p.PassengerInStationId == id);
            //TODO TE.SaveChanges();
        }
    }
}


