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
    public class TransportationService
    {
        private readonly IMongoCollection<Transportation> transportations;
        private readonly IMapper mapper;

        public TransportationService(IDatabaseSettings settings, IMapper map)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            transportations = database.GetCollection<Transportation>(this.GetType().Name+"s");

            mapper = map;
        }

        public List<TransportationDTO> GetAllTransportationsList()
        {
            return mapper.Map<List<TransportationDTO>>(transportations.Find(_ => true).ToList());
        }

        public  TransportationDTO GetTransportationsById(string id)
        {
            return mapper.Map<TransportationDTO>(transportations.Find(t=> t.TransportationId == id).ToList().FirstOrDefault()); 
        }

        public  void AddTransportationsToList(TransportationDTO transportation)
        {
            transportations.InsertOne(mapper.Map<Transportation>(transportation));
        }

        public  void PutTransportations(TransportationDTO transportation)
        {
            transportations.ReplaceOne(t => t.TransportationId == transportation.TransportationId, mapper.Map<Transportation>(transportation));
        }

        public  void DeleteTransportations(string id)
        {
            //Transportation transportations = TE.Transportation.Where(t => t.TransportationId.Equals(id)).FirstOrDefault();
            //TE.Transportation.Remove(transportations);
            transportations.DeleteOne(t => t.TransportationId == id);
        }

        public List<string> GetAddressList(string transportationId)
        {
            var address = transportations.AsQueryable()
                .Where(t => t.TransportationId == transportationId)
                .Select(t=> t.Address);
            return address.ToList();
        }
    }
}