using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using MongoDB.Bson.Serialization.Attributes;

namespace ViewModel
{
    public class EstablishmentDTO
    {
        [BsonId]
        public string EstablishmentId { get; set; }
        public string Address { get; set; }
        public string EstablishmentName { get; set; }
        public string CelContactMan { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public static EstablishmentDTO ConvertToEstablishmentDTO(Establishments e)
        {
            return new EstablishmentDTO()
            {
                EstablishmentId = e.EstablishmentId,
                Address= e.Address,
                EstablishmentName = e.EstablishmentName,
                CelContactMan=e.CelContactMan,
                Email = e.Email,
                Password=e.Password
                
            };
        }

        public static List<EstablishmentDTO> ConvertToEstablishmentDTOList(List<Establishments> eList)
        {
            var ListDTO = from e in eList
                          select new EstablishmentDTO()
                          {
                              EstablishmentId = e.EstablishmentId,
                              Address = e.Address,
                              EstablishmentName = e.EstablishmentName,
                              CelContactMan = e.CelContactMan,
                              Email = e.Email,
                              Password = e.Password
                          };
            return ListDTO.ToList();
        }

        public static Establishments ConvertToEstablishment(EstablishmentDTO e)
        {
            return new Establishments()
            {
                EstablishmentId = e.EstablishmentId,
                Address = e.Address,
                EstablishmentName = e.EstablishmentName,
                CelContactMan = e.CelContactMan,
                Email = e.Email,
                Password = e.Password
            };
        }

        public static List<Establishments> ConvertToEstablishmentList(List<EstablishmentDTO> eList)
        {
            var List = from e in eList
                       select new Establishments()
                       {
                           EstablishmentId = e.EstablishmentId,
                           Address = e.Address,
                           EstablishmentName = e.EstablishmentName,
                           CelContactMan = e.CelContactMan,
                           Email = e.Email,
                           Password = e.Password
                       };
            return List.ToList();
        }
    }
}
