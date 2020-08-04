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
    public class ChildInFamilyService
    {
        private readonly IMongoCollection<ChildInFamily> childInFamily;
        private readonly IMongoCollection<Family> family;
        public ChildInFamilyService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            childInFamily = database.GetCollection<ChildInFamily>(this.GetType().Name);
        }
        public  List<ChildInFamilyDTO> GetAllChildInFamilyList()
        {
            return ChildInFamilyDTO.ConvertToChildInFamilyDTOList(childInFamily.Find(_=>true).ToList());
        }

        public  ChildInFamilyDTO GetChildInFamilyByName(string name)
        {
            return ChildInFamilyDTO.ConvertToChildInFamilyDTO(childInFamily.Find(c=>c.Name==name).ToList().FirstOrDefault());
        }

        public static FamilyDTO GetFamilyByChildId(string childId)
        {
            var familyId = from c in GetAllChildInFamilyList()
                           where c.ChildInFamilyId == childId
                           select c.FamilyId;
            return FamilyDTO.ConvertToFamilyDTO(family.Find(f => f.FamilyId == familyId.ToString()).FirstOrDefault());
        }

        public  void AddChildInFamilyToList(ChildInFamilyDTO childInFamily)
        {
            this.childInFamily.InsertOne(ChildInFamilyDTO.ConvertToChildInFamily(childInFamily));
            //TODO //TODO TE.SaveChanges();
        }

        public  void PutChildInFamily(ChildInFamilyDTO childInFam)
        {
            childInFamily.ReplaceOne(c => c.ChildInFamilyId == childInFam.ChildInFamilyId, ChildInFamilyDTO.ConvertToChildInFamily(childInFam));
        }

        public  void DeleteChildInFamily(string id)
        {
            childInFamily.DeleteOne(c => c.ChildInFamilyId == id);
            //TODO TE.SaveChanges();
        }
    }
}


