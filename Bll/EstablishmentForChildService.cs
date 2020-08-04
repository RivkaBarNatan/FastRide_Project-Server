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
    public class EstablishmentForChildService
    {
        private readonly IMongoCollection<EstablishmentForChild> establishmentForChild;
        public EstablishmentForChildService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            establishmentForChild = database.GetCollection<EstablishmentForChild>(this.GetType().Name);
        }
        public  List<EstablishmentForChildDTO> GetAllEstablishmentForChildList()
        {
            return EstablishmentForChildDTO.ConvertToEstablishmentForChildDTOList(establishmentForChild.Find(_=>true).ToList());
        }

        public  EstablishmentForChildDTO GetEstablishmentForChildByIdChild(string id)
        {
            return EstablishmentForChildDTO.ConvertToEstablishmentForChildDTO(establishmentForChild.Find(e=>e.EstablishmentForChildId==id).ToList().FirstOrDefault());
        }

        public  void AddEstablishmentForChildToList(EstablishmentForChildDTO establishmentForChild)
        {
            this.establishmentForChild.InsertOne(EstablishmentForChildDTO.ConvertToEstablishmentForChild(establishmentForChild));
            //TODO TE.SaveChanges();
        }

        public  void PutEstablishmentForChild(EstablishmentForChildDTO establishmentForChild)
        {
            this.establishmentForChild.ReplaceOne(e => e.EstablishmentForChildId == establishmentForChild.EstablishmentForChildId, EstablishmentForChildDTO.ConvertToEstablishmentForChild(establishmentForChild));
        }

        public  void DeleteEstablishmentForChild(string id)
        {
            establishmentForChild.DeleteOne(e => e.EstablishmentForChildId == id);
            //TODO TE.SaveChanges();
        }
    }
}


