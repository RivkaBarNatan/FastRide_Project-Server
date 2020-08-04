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
    public class TrackService
    {
        private readonly IMongoCollection<Track> track;
        public TrackService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            track = database.GetCollection<Track>(this.GetType().Name);
        }
        public  List<TrackDTO> GetAllTrackList()
        {
            return TrackDTO.ConvertToTrackDTOList(track.Find(_=>true).ToList());
        }

        public  TrackDTO GetTrackByEstablishmentId(string id)
        {
            return TrackDTO.ConvertToTrackDTO(track.Find(t=>t.TrackId==id).ToList().FirstOrDefault());
        }

        public  void AddTrackToList(TrackDTO track)
        {
            this.track.InsertOne(TrackDTO.ConvertToTrack(track));
            //TODO TE.SaveChanges();
        }

        public  void PutTrack(TrackDTO trac)
        {
            track.ReplaceOne(t => t.TrackId == trac.TrackId, TrackDTO.ConvertToTrack(trac));

            //TODO TE.SaveChanges();
        }

        public  void DeleteTrack(string id)
        {
            track.DeleteOne(t => t.TrackId == id);
            //TODO TE.SaveChanges();
        }
    }
}


