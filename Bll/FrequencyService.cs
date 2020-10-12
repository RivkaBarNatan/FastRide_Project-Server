using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using DAL;
using MongoDB.Driver;
using AutoMapper;

namespace BL
{
    public class FrequencyService
    {
        private readonly IMapper mapper;
        private readonly IMongoCollection<Frequency> frequency;
        public FrequencyService(IDatabaseSettings settings, IMapper map)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            frequency = database.GetCollection<Frequency>(this.GetType().Name);

            mapper = map;
        }
        public  List<FrequencyDTO> GetAllFrequencyList()
        {
            return mapper.Map<List<FrequencyDTO>>(frequency.Find(_ => true).ToList());
        }

        public  FrequencyDTO GetFrequencyByType(string type)
        {
            return mapper.Map<FrequencyDTO>(frequency.Find(f => f.FrequencyType == type).ToList().FirstOrDefault());
        }

        public  void AddFrequencyToList(FrequencyDTO frequency)
        {
            this.frequency.InsertOne(mapper.Map<Frequency>(frequency));
        }

        public  void PutFrequency(FrequencyDTO freq)
        {
            frequency.ReplaceOne(f => f.FrequencyId == freq.FrequencyId, mapper.Map<Frequency>(freq));
        }

        public  void DeleteFrequency(string id)
        {
            frequency.DeleteOne(f => f.FrequencyId == id);
        }
    }
}


