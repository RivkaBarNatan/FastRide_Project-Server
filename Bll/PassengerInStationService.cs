using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using DAL;
using MongoDB.Driver;

namespace BL
{
    public class PassengerInStationService
   {
        //        private readonly IMongoCollection<PassengerInStation> passengerInStation;
        //        private readonly StationService stationSer;

        //        public PassengerInStationService(IDatabaseSettings settings)
        //        {
        //            var client = new MongoClient(settings.ConnectionString);
        //            var database = client.GetDatabase(settings.DatabaseName);
        //            passengerInStation = database.GetCollection<PassengerInStation>(this.GetType().Name);
        //        }
        //        public  List<PassengerInStationDTO> GetAllPassengerInStationList()
        //        {
        //            return PassengerInStationDTO.ConvertToPassengerInStationDTOList(passengerInStation.Find(_=>true).ToList());
        //        }

        //        public  PassengerInStationDTO GetPassengerInStationById(string id)
        //        {
        //            return PassengerInStationDTO.ConvertToPassengerInStationDTO(passengerInStation.Find(p=>p.PassengerInStationId==id).ToList().FirstOrDefault());
        //        }

        //        public  void AddPassengerInStationToList(PassengerInStationDTO passengerInStation)
        //        {
        //            this.passengerInStation.InsertOne(PassengerInStationDTO.ConvertToPassengerInStation(passengerInStation));
        //            //TODO TE.SaveChanges();
        //        }

        //        public  void PutPassengerInStation(PassengerInStationDTO passengerInStat)
        //        {

        //            passengerInStation.ReplaceOne(p => p.PassengerInStationId == passengerInStat.PassengerInStationId, PassengerInStationDTO.ConvertToPassengerInStation(passengerInStat));
        //        }

        //        public  void DeletePassengerInStation(string id)
        //        {
        //            passengerInStation.DeleteOne(p => p.PassengerInStationId == id);
        //            //TODO TE.SaveChanges();
        //        }
        //public long[] GetCountPassengerInStationAtHour(TimeSpan hour)
        //{
        //    long[] cList;
        //    for (int i = 0; i < stationSer.GetAllStationsList().Count; i++)
        //    {
        //        var ddd=from x in stationSer.GetAllStationsList()
        //                select from j in GetAllPassengerInStationList()
        //                       where j.StationId == stationSer.GetAllStationsList()[i].StationId && hour == j.Hour
        //                       select j;
        //        cList[i]=c.Count();
        //    }
        //    return cList;
        //}
        //        public List<string> GetAllStationAtHour(TimeSpan hour)
        //        {
        //            var x = from s in passengerInStation.Find(p => p.Hour == hour).ToList()
        //                    select stationSer.GetStationsById(s.StationId).Address;
        //            return x.ToList();
        //        }

    }
}