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
        private readonly StationService stationSer;

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
        public List<int> GetCountPassengerInStationAtHour(TimeSpan hour)
        {
            //var passengerInStationList = GetAllPassengerInStationList();
            //var StationList = stationSer.GetAllStationsList();
            //int[] countArray;
            //int num = 0;
            //for (int i = 0; i < StationList.Count; i++)
            //{
            //    for (int j = 0; j < passengerInStationList.Count; j++)
            //    {
            //        if (passengerInStationList[j].StationId == StationList[i].StationId && passengerInStationList[j].Hour == hour)
            //            num += 1;
            //    }
            //    countArray = num;
            //    num = 0;
            //}
            List<int> cList= new List<int>();
            for (int i = 0; i < stationSer.GetAllStationsList().Count; i++)
            {
                int num = 0;
                //var a = from y in passInStatSer.GetAllPassengerInStationList()
                //        where y.StationId == stationSer.GetAllStationsList()[i].StationId && hour == y.Hour
                //        select num += 1;

                for (int j = 0; j < GetAllPassengerInStationList().Count; j++)
                {
                    if (GetAllPassengerInStationList()[j].StationId == stationSer.GetAllStationsList()[i].StationId
                        && hour == GetAllPassengerInStationList()[j].Hour)
                        num++;
                }
                cList.Add(num);
            }
            return cList;
        }
        public List<string> GetAllStationAtHour(TimeSpan hour)
        {
            var x = from s in passengerInStation.Find(p => p.Hour == hour).ToList()
                    select stationSer.GetStationsById(s.StationId).Address;
            return x.ToList();
        }

    }
}