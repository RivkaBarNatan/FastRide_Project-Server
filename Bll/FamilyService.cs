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
    public class FamilyService
    {
        private readonly IMongoCollection<Family> family;
        public FamilyService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            family = database.GetCollection<Family>(this.GetType().Name);
        }
        public  List<FamilyDTO> GetAllFamilyList()
        {
            return FamilyDTO.ConvertToFamilyDTOList(family.Find(_=>true).ToList());
        }

        public  FamilyDTO GetFamilyByUserName(string name)
        {
            return FamilyDTO.ConvertToFamilyDTO(family.Find(f=>f.UserName==name).ToList().FirstOrDefault()); ;
        }

        public  void AddFamilyToList(FamilyDTO family)
        {
            this.family.InsertOne(FamilyDTO.ConvertToFamily(family));
            //TODO TE.SaveChanges();
        }

        public bool ChekIfPasswordIsExist(string userName, string password)
        {
            bool isExist = false;
            List<Family> lf = family.Find(_ => true).ToList();
            for (int i = 0; i < lf.Count; i++)
            {
                if (lf[i].UserName.Equals(userName) && lf[i].Password.Equals(password))
                    isExist = true;
            }
            return !isExist;
        }
        public  void PutFamily(FamilyDTO fam)
        {
            family.ReplaceOne(f => f.FamilyId == fam.FamilyId, FamilyDTO.ConvertToFamily(fam));
            //TODO TE.SaveChanges();
        }

        public  void DeleteFamily(string id)
        {
            family.DeleteOne(f => f.FamilyId == id);
            //TODO TE.SaveChanges();
        }
    }
}
