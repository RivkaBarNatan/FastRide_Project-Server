using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using ViewModel;

namespace UI
{
    public class StationInTrackFunction
    {
        public int StationInTrackId { get; set; }
        public int TrackId { get; set; }
        public int StationId { get; set; }
        public int OrdinalNumberInTrack { get; set; }

        

        static TransportationDBEntities TE = new TransportationDBEntities();
        public static List<StationInTrackDTO> GetAllStationInTrackList()
        {
            return StationInTrackDTO.ConvertToStationInTrackDTOList(TE.StationInTrack.ToList());
        }

        public static StationInTrackDTO GetStationInTrackById(int id)
        {
            StationInTrack stationInTrack = TE.StationInTrack.Where(s => s.StationInTrackId.Equals(id)).FirstOrDefault();
            return StationInTrackDTO.ConvertToStationInTrackDTO(stationInTrack);
        }

        public static void AddStationInTrackToList(StationInTrackDTO stationInTrack)
        {
            TE.StationInTrack.Add(StationInTrackDTO.ConvertToStationInTrack(stationInTrack));
            //TODO TE.SaveChanges();
        }

        public static void PutStationInTrack(StationInTrackDTO stationInTrack)
        {
            StationInTrack stationsInTrack = TE.StationInTrack.Where(s => s.StationInTrackId.Equals(stationInTrack.StationInTrackId)).FirstOrDefault();
            stationsInTrack.OrdinalNumberInTrack = stationInTrack.OrdinalNumberInTrack;
            stationsInTrack.StationId = stationInTrack.StationId;
            stationsInTrack.TrackId = stationInTrack.TrackId;
            //TODO TE.SaveChanges();
        }

        public static void DeleteStationstationInTrack(int id)
        {
            StationInTrack stationInTrack = TE.StationInTrack.Where(s => s.StationInTrackId.Equals(id)).FirstOrDefault();
            TE.StationInTrack.Remove(stationInTrack);
            //TODO TE.SaveChanges();
        }
    }
}


