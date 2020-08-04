using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using MongoDB.Bson.Serialization.Attributes;

namespace ViewModel
{
    public class ChildInFamilyDTO
    {
        [BsonId]
        public string ChildInFamilyId { get; set; }
        public string Name { get; set; }
        public string FamilyId { get; set; }

        public static ChildInFamilyDTO ConvertToChildInFamilyDTO(ChildInFamily c)
        {
            return new ChildInFamilyDTO()
            {
                ChildInFamilyId = c.ChildInFamilyId,
                Name = c.Name,
                FamilyId = c.FamilyId
               
            };
        }
        public static List<ChildInFamilyDTO> ConvertToChildInFamilyDTOList(List<ChildInFamily> cl)
        {
            var DTOList = from c in cl
                          select new ChildInFamilyDTO()
                          {
                              ChildInFamilyId = c.ChildInFamilyId,
                              Name = c.Name,
                              FamilyId = c.FamilyId
                          };
            return DTOList.ToList();
        }
        public static ChildInFamily ConvertToChildInFamily(ChildInFamilyDTO c)
        {
            return new ChildInFamily()
            {
                ChildInFamilyId = c.ChildInFamilyId,
                Name = c.Name,
                FamilyId = c.FamilyId
            };
        }
        public static List<ChildInFamily> ConvertToChildInFamilyList(List<ChildInFamilyDTO> cl)
        {
            var ChildInFamilyList = from c in cl
                               select new ChildInFamily()
                               {
                                   ChildInFamilyId = c.ChildInFamilyId,
                                   Name = c.Name,
                                   FamilyId = c.FamilyId
                               };
            return ChildInFamilyList.ToList();
        }
    }
}

