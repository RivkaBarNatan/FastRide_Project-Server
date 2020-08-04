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
    public class FrequencyService
    {
        private readonly IMongoCollection<Frequency> frequency;
        public FrequencyService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            frequency = database.GetCollection<Frequency>(this.GetType().Name);
        }
        public  List<FrequencyDTO> GetAllFrequencyList()
        {
            return FrequencyDTO.ConvertToFrequencyDTOList(frequency.Find(_=>true).ToList());
        }

        public  FrequencyDTO GetFrequencyByType(string type)
        {
            return FrequencyDTO.ConvertToFrequencyDTO(frequency.Find(f=>f.FrequencyType==type).ToList().FirstOrDefault());
        }

        public  void AddFrequencyToList(FrequencyDTO frequency)
        {
            this.frequency.InsertOne(FrequencyDTO.ConvertToFrequency(frequency));
            //TODO TE.SaveChanges();
        }

        public  void PutFrequency(FrequencyDTO freq)
        {
            frequency.ReplaceOne(f => f.FrequencyId == freq.FrequencyId, FrequencyDTO.ConvertToFrequency(freq));
        }

        public  void DeleteFrequency(string id)
        {
            frequency.DeleteOne(f => f.FrequencyId == id);
            //TODO TE.SaveChanges();
        }
    }
}


