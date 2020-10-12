using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ViewModel;
using MongoDB.Driver;
using AutoMapper;


namespace BL
{
    public class TrackService
    {
        private readonly IMongoCollection<Track> track;
        private readonly IMapper mapper;
        public TrackService(IDatabaseSettings settings, IMapper map)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            track = database.GetCollection<Track>(this.GetType().Name);

            mapper = map;
        }
        public  List<TrackDTO> GetAllTrackList()
        {
            return mapper.Map<List<TrackDTO>>(track.Find(_=>true).ToList());
        }

        public  TrackDTO GetTrackByEstablishmentId(string id)
        {
            return mapper.Map<TrackDTO>(track.Find(t=>t.TrackId==id).ToList().FirstOrDefault());
        }

        public  void AddTrackToList(TrackDTO track)
        {
            this.track.InsertOne(mapper.Map<Track>(track));
        }

        public  void PutTrack(TrackDTO trac)
        {
            track.ReplaceOne(t => t.TrackId == trac.TrackId, mapper.Map<Track>(trac));
        }

        public  void DeleteTrack(string id)
        {
            track.DeleteOne(t => t.TrackId == id);
        }
    }
}


