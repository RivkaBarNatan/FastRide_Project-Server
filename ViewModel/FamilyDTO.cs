using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using MongoDB.Bson.Serialization.Attributes;

namespace ViewModel
{
    public class FamilyDTO
    {
        [BsonId]
        public string FamilyId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Phelephone { get; set; }

        public static FamilyDTO ConvertToFamilyDTO(Family f)
        {
            return new FamilyDTO()
            {
                FamilyId = f.FamilyId,
                UserName = f.UserName,
                Password = f.Password,
                Email = f.Email,
                Address = f.Address,
                Telephone = f.Telephone,
                Phelephone = f.Phelephone
               
            };
        }
        public static List<FamilyDTO> ConvertToFamilyDTOList(List<Family> fl)
        {
            var DTOList = from f in fl
                          select new FamilyDTO()
                          {
                              FamilyId = f.FamilyId,
                              UserName = f.UserName,
                              Password = f.Password,
                              Email = f.Email,
                              Address = f.Address,
                              Telephone = f.Telephone,
                              Phelephone = f.Phelephone
                          };
            return DTOList.ToList();
        }
        public static Family ConvertToFamily(FamilyDTO f)
        {
            return new Family()
            {
                FamilyId = f.FamilyId,
                UserName = f.UserName,
                Password = f.Password,
                Email = f.Email,
                Address = f.Address,
                Telephone = f.Telephone,
                Phelephone = f.Phelephone
            };
        }
        public static List<Family> ConvertToFamilyList(List<FamilyDTO> fl)
        {
            var FamilyList = from f in fl
                             select new Family()
                               {
                                   FamilyId = f.FamilyId,
                                   UserName = f.UserName,
                                   Password = f.Password,
                                   Email = f.Email,
                                   Address = f.Address,
                                   Telephone = f.Telephone,
                                   Phelephone = f.Phelephone
                               };
            return FamilyList.ToList();
        }

    }
}
