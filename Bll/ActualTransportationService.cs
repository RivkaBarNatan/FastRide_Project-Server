using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using ViewModel;
using MongoDB.Driver;

namespace BL
{
   public class ActualTransportationService
    {
        private readonly IMongoCollection<ActualTransportation> actualTransportation;
        public ActualTransportationService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            actualTransportation = database.GetCollection<ActualTransportation>(this.GetType().Name);
        }
        public  List<ActualTransportationDTO> GetAllActualTransportationList()
        {
            return ActualTransportationDTO.ConvertToActualTransportationDTOList(actualTransportation.Find(_=>true).ToList());
        }

        public  ActualTransportationDTO GetActualTransportationByTransportationId(string id)
        {
            return ActualTransportationDTO.ConvertToActualTransportationDTO(actualTransportation.Find(a=>a.ActualTransportationId==id).ToList().FirstOrDefault());
        }

        public  void AddActualTransportationToList(ActualTransportationDTO actualTransportation)
        {
            this.actualTransportation.InsertOne(ActualTransportationDTO.ConvertToActualTransportation(actualTransportation));
            //TODO //TODO TE.SaveChanges();
        }

        public  void PutActualTransportation(ActualTransportationDTO ActualTrans)
        {
            actualTransportation.ReplaceOne(a => a.ActualTransportationId == ActualTrans.ActualTransportationId, ActualTransportationDTO.ConvertToActualTransportation(ActualTrans));
        }

        public  void DeleteActualTransportation(string id)
        {
            actualTransportation.DeleteOne(a => a.ActualTransportationId == id);
            //TODO //TODO TE.SaveChanges();
        }
    }
}


