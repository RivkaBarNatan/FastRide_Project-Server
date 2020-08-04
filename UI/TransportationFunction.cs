using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using Dal;

namespace UI
{
    public class TransportationFunction
    {

    
        static TransportationDBEntities TE = new TransportationDBEntities();
        public static List<TransportationDTO> GetAllTransportationsList()
        {
            return TransportationDTO.ConvertToTransportationDTOList(TE.Transportation.ToList());
        }

        public static TransportationDTO GetTransportationsById(int id)
        {
            Transportation transportations = TE.Transportation.Where(t => t.TransportationId.Equals(id)).FirstOrDefault();
            return TransportationDTO.ConvertToTransportationDTO(transportations);
        }

        public static void AddTransportationsToList(TransportationDTO transportation)
        {
            TE.Transportation.Add(TransportationDTO.ConvertToTransportation(transportation));
            //TODO TE.SaveChanges();
        }

        public static void PutTransportations(TransportationDTO transportation)
        {
            Transportation transportations = TE.Transportation.Where(t => t.TransportationId.Equals(transportation.TransportationId)).FirstOrDefault();
            transportations.StartTime = transportation.StartTime;
            transportations.SourceAddress = transportation.SourceAddress;
            transportations.VehicleId = transportation.VehicleId;
            transportations.Price = transportation.Price;
            //TODO TE.SaveChanges();
        }

        public static void DeleteTransportations(int id)
        {
            Transportation transportations = TE.Transportation.Where(t => t.TransportationId.Equals(id)).FirstOrDefault();
            TE.Transportation.Remove(transportations);
            //TODO TE.SaveChanges();
        }
    }
}