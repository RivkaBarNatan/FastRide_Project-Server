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
    public class TransportationService
    {
        private readonly IMongoCollection<Transportation> transportations;

        public TransportationService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            transportations = database.GetCollection<Transportation>(this.GetType().Name+"s");
        }

        public List<TransportationDTO> GetAllTransportationsList()
        {
            return TransportationDTO.ConvertToTransportationDTOList(transportations.Find(_ => true).ToList());
        }

        public  TransportationDTO GetTransportationsById(string id)
        {
            return TransportationDTO.ConvertToTransportationDTOList(transportations.Find(t=> t.TransportationId == id).ToList()).FirstOrDefault(); 
        }

        public  void AddTransportationsToList(TransportationDTO transportation)
        {
            transportations.InsertOne(TransportationDTO.ConvertToTransportation(transportation));
        }

        public  void PutTransportations(TransportationDTO transportation)
        {
            transportations.ReplaceOne(t => t.TransportationId == transportation.TransportationId, TransportationDTO.ConvertToTransportation(transportation));
            //TODO TE.SaveChanges();
        }

        public  void DeleteTransportations(string id)
        {
            //Transportation transportations = TE.Transportation.Where(t => t.TransportationId.Equals(id)).FirstOrDefault();
            //TE.Transportation.Remove(transportations);
            transportations.DeleteOne(t => t.TransportationId == id);
            //TODO TE.SaveChanges();
        }
    }
}