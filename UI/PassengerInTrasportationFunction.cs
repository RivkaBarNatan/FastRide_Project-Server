using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using ViewModel;

namespace UI
{
    public class PassengerInTrasportationFunction
    {

        static TransportationDBEntities TE = new TransportationDBEntities();
        public static List<PassengerInTransportationDTO> GetAllPassengerInTransportationList()
        {
            return PassengerInTransportationDTO.ConvertToPassengerInTransportationDTOList(TE.PassengerInTransportation.ToList());
        }

        public static PassengerInTransportationDTO GetPassengerInTransportationByPassengerId(int id)
        {
            PassengerInTransportation passengerInTransportation = TE.PassengerInTransportation.Where(p => p.PassengerId == id).FirstOrDefault();
            return PassengerInTransportationDTO.ConvertToPassengerInTransportationDTO(passengerInTransportation);
        }

        public static void AddPassengerInTransportationToList(PassengerInTransportationDTO passengerInTransportation)
        {
            TE.PassengerInTransportation.Add(PassengerInTransportationDTO.ConvertToPassengerInTransportation(passengerInTransportation));
            //TODO TE.SaveChanges();
        }

        public static void PutPassengerInTransportation(PassengerInTransportationDTO passengerInTrans)
        {
            PassengerInTransportation passengerInTransportation = TE.PassengerInTransportation.Where(p => p.PassengerInTransportationId.Equals(passengerInTrans.PassengerInTransportationId)).FirstOrDefault();
            passengerInTransportation.TransportationId = passengerInTrans.TransportationId;
            passengerInTransportation.PassengerId = passengerInTrans.PassengerId;

            //TODO TE.SaveChanges();
        }

        public static void DeletePassengerInTransportation(int id)
        {
            PassengerInTransportation passengerInTransportation = TE.PassengerInTransportation.Where(p => p.PassengerInTransportationId.Equals(id)).FirstOrDefault();
            TE.PassengerInTransportation.Remove(passengerInTransportation);
            //TODO TE.SaveChanges();
        }
    }
}
