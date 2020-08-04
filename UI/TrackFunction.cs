using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using ViewModel;


namespace UI
{
    public class TrackFunction
    {
  
        static TransportationDBEntities TE = new TransportationDBEntities();
        public static List<TrackDTO> GetAllTrackList()
        {
            return TrackDTO.ConvertToTrackDTOList(TE.Track.ToList());
        }

        public static TrackDTO GetTrackByEstablishmentId(int id)
        {
            Track track = TE.Track.Where(t => t.EstablishmentId==id).FirstOrDefault();
            return TrackDTO.ConvertToTrackDTO(track);
        }

        public static void AddTrackToList(TrackDTO track)
        {
            TE.Track.Add(TrackDTO.ConvertToTrack(track));
            //TODO TE.SaveChanges();
        }

        public static void PutTrack(TrackDTO trac)
        {
            Track track = TE.Track.Where(t => t.TrackId.Equals(trac.TrackId)).FirstOrDefault();
            track.Ingathering_Interspersion = trac.Ingathering_Interspersion;
            track.FrequencyId = trac.FrequencyId;
            track.TrackPrice = trac.TrackPrice;
            track.EstablishmentId = trac.EstablishmentId;
            track.Destination_Source = trac.Destination_Source;

            //TODO TE.SaveChanges();
        }

        public static void DeleteTrack(int id)
        {
            Track track = TE.Track.Where(v => v.TrackId.Equals(id)).FirstOrDefault();
            TE.Track.Remove(track);
            //TODO TE.SaveChanges();
        }
    }
}


