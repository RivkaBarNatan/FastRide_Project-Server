using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using MongoDB.Bson.Serialization.Attributes;

namespace ViewModel
{
    public class EstablishmentForChildDTO
    {
        [BsonId]
        public string EstablishmentForChildId { get; set; }
        public string EstablishmentId { get; set; }
        public string ChildId { get; set; }

        
        public static EstablishmentForChildDTO ConvertToEstablishmentForChildDTO(EstablishmentForChild e)
        {
            return new EstablishmentForChildDTO()
            {
                EstablishmentForChildId = e.EstablishmentForChildId,
                EstablishmentId = e.EstablishmentId,
                ChildId=e.ChildId
            };
        }

        public static List<EstablishmentForChildDTO> ConvertToEstablishmentForChildDTOList(List<EstablishmentForChild> eList)
        {
            var ListDTO = from e in eList
                          select new EstablishmentForChildDTO()
                          {
                              EstablishmentForChildId = e.EstablishmentForChildId,
                              EstablishmentId = e.EstablishmentId,
                              ChildId = e.ChildId
                          };
            return ListDTO.ToList();
        }

        public static EstablishmentForChild ConvertToEstablishmentForChild(EstablishmentForChildDTO e)
        {
            return new EstablishmentForChild()
            {
                EstablishmentForChildId = e.EstablishmentForChildId,
                EstablishmentId = e.EstablishmentId,
                ChildId = e.ChildId
            };
        }

        public static List<EstablishmentForChild> ConvertToEstablishmentForChildList(List<EstablishmentForChildDTO> eList)
        {
            var List = from e in eList
                       select new EstablishmentForChild()
                       {
                           EstablishmentForChildId = e.EstablishmentForChildId,
                           EstablishmentId = e.EstablishmentId,
                           ChildId = e.ChildId
                       };
            return List.ToList();
        }
    }
}
