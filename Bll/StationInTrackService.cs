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
    public class StationInTrackService
    {
        //public int StationInTrackId { get; set; }
        //public int TrackId { get; set; }
        //public int StationId { get; set; }
        //public int OrdinalNumberInTrack { get; set; }


        private readonly IMongoCollection<StationInTrack> stationInTrack;
        public StationInTrackService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            stationInTrack = database.GetCollection<StationInTrack>(this.GetType().Name);
        }
        public  List<StationInTrackDTO> GetAllStationInTrackList()
        {
            return StationInTrackDTO.ConvertToStationInTrackDTOList(stationInTrack.Find(_=>true).ToList());
        }

        public  StationInTrackDTO GetStationInTrackById(string id)
        {
            return StationInTrackDTO.ConvertToStationInTrackDTO(stationInTrack.Find(s => s.StationInTrackId == id).ToList().FirstOrDefault());
        }

        public  void AddStationInTrackToList(StationInTrackDTO stationInTrack)
        {
            this.stationInTrack.InsertOne(StationInTrackDTO.ConvertToStationInTrack(stationInTrack));
            //TODO TE.SaveChanges();
        }

        public  void PutStationInTrack(StationInTrackDTO stationInTrack)
        {
            this.stationInTrack.ReplaceOne(s => s.StationInTrackId == stationInTrack.StationInTrackId, StationInTrackDTO.ConvertToStationInTrack(stationInTrack));
            //stationsInTrack.OrdinalNumberInTrack = stationInTrack.OrdinalNumberInTrack;
            //stationsInTrack.StationId = stationInTrack.StationId;
            //stationsInTrack.TrackId = stationInTrack.TrackId;
            //TODO TE.SaveChanges();
        }

        public  void DeleteStationstationInTrack(string id)
        {
            stationInTrack.DeleteOne(s => s.StationInTrackId == id);
            //TODO TE.SaveChanges();
        }
    }
}


