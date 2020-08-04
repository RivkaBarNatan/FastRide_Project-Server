using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using Dal;

namespace UI
{
    public class PassengerInStationFunction
    {

        static TransportationDBEntities TE = new TransportationDBEntities();
        public static List<PassengerInStationDTO> GetAllPassengerInStationList()
        {
            return PassengerInStationDTO.ConvertToPassengerInStationDTOList(TE.PassengerInStation.ToList());
        }

        public static PassengerInStationDTO GetPassengerInStationById(int id)
        {
            PassengerInStation passengerInStation = TE.PassengerInStation.Where(p => p.PassengerInStationId.Equals(id)).FirstOrDefault();
            return PassengerInStationDTO.ConvertToPassengerInStationDTO(passengerInStation);
        }

        public static void AddPassengerInStationToList(PassengerInStationDTO passengerInStation)
        {
            TE.PassengerInStation.Add(PassengerInStationDTO.ConvertToPassengerInStation(passengerInStation));
            //TODO TE.SaveChanges();
        }

        public static void PutPassengerInStation(PassengerInStationDTO passengerInStat)
        {
            PassengerInStation passengerInStation = TE.PassengerInStation.Where(p => p.PassengerInStationId.Equals(passengerInStat.PassengerInStationId)).FirstOrDefault();
            passengerInStation.StationId = passengerInStat.StationId;
            passengerInStation.Hour = passengerInStat.Hour;
            passengerInStation.PassengerId = passengerInStat.PassengerId;
            //TODO TE.SaveChanges();
        }

        public static void DeletePassengerInStation(int id)
        {
            PassengerInStation passengerInStation = TE.PassengerInStation.Where(p => p.PassengerInStationId.Equals(id)).FirstOrDefault();
            TE.PassengerInStation.Remove(passengerInStation);
            //TODO TE.SaveChanges();
        }
    }
}


