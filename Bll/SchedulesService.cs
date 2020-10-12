using System;
using System.Collections.Generic;
using System.Text;
using BL;
using DAL;
using AutoMapper;
using MongoDB.Driver;
using ViewModel;
using System.Linq;

namespace BL
{
    public class SchedulesService
    {
        private readonly IMongoCollection<Schedules> schedules;
        private readonly IMapper mapper;
        public SchedulesService(IDatabaseSettings settings, IMapper map)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            schedules = database.GetCollection<Schedules>(this.GetType().Name);

            mapper = map;
        }
        public List<SchedulesDTO> GetAllSchedulesList()
        {
            return mapper.Map<List<SchedulesDTO>>(schedules.Find(_ => true).ToList());
        }

        public SchedulesDTO GetScheduleById(string id)
        {
            return mapper.Map<SchedulesDTO>(schedules.Find(s => s.SchduleId == id).ToList().FirstOrDefault());
        }

        public void AddScheduleToList(SchedulesDTO schedule)
        {
            schedules.InsertOne(mapper.Map<Schedules>(schedule));
        }

        public void PutSchedule(SchedulesDTO schedule)
        {
            schedules.ReplaceOne(s => s.SchduleId == schedule.ScheduleId, mapper.Map<Schedules>(schedule));
        }

        public void DeleteSchedule(string id)
        {
            schedules.DeleteOne(s => s.SchduleId == id);
        }
    }
}
