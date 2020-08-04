using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using MongoDB.Bson.Serialization.Attributes;

namespace ViewModel
{
    public class FrequencyDTO
    {
        [BsonId]
        public string FrequencyId { get; set; }
        public string FrequencyType { get; set; }

        public static FrequencyDTO ConvertToFrequencyDTO(Frequency f)
        {
            return new FrequencyDTO()
            {
                FrequencyId = f.FrequencyId,
                FrequencyType = f.FrequencyType
            };
        }

        public static List<FrequencyDTO> ConvertToFrequencyDTOList(List<Frequency> fList)
        {
            var ListDTO = from f in fList
                          select new FrequencyDTO()
                          {
                              FrequencyId = f.FrequencyId,
                              FrequencyType = f.FrequencyType
                          };
            return ListDTO.ToList();
        }

        public static Frequency ConvertToFrequency(FrequencyDTO f)
        {
            return new Frequency()
            {
                FrequencyId = f.FrequencyId,
                FrequencyType = f.FrequencyType
            };
        }

        public static List<Frequency> ConvertToFrequencyList(List<FrequencyDTO> fList)
        {
            var List = from f in fList
                       select new Frequency()
                       {
                           FrequencyId = f.FrequencyId,
                           FrequencyType = f.FrequencyType
                       };
            return List.ToList();
        }
    }
}

