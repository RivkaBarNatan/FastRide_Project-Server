using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using MongoDB.Bson.Serialization.Attributes;

namespace ViewModel
{
    public class TrackDTO
    {
        [BsonId]
        public string TrackId { get; set; }
        public string EstablishmentId { get; set; }
        public string Destination_Source { get; set; }
        public string Ingathering_Interspersion { get; set; }
        public string FrequencyId { get; set; }
        public int TrackPrice { get; set; }

        public static TrackDTO ConvertToTrackDTO(Track t)
        {
            return new TrackDTO()
            {
                TrackId = t.TrackId,
                EstablishmentId = t.EstablishmentId,
                Destination_Source=t.Destination_Source,
                Ingathering_Interspersion=t.Ingathering_Interspersion,
                FrequencyId=t.FrequencyId,
                TrackPrice=t.TrackPrice.Value
            };
        }
        public static List<TrackDTO> ConvertToTrackDTOList(List<Track> tl)
        {
            var DTOList = from t in tl
                          select new TrackDTO()
                          {
                              TrackId = t.TrackId,
                              EstablishmentId = t.EstablishmentId,
                              Destination_Source = t.Destination_Source,
                              Ingathering_Interspersion = t.Ingathering_Interspersion,
                              FrequencyId = t.FrequencyId,
                              TrackPrice = t.TrackPrice.Value
                          };
            return DTOList.ToList();
        }
        public static Track ConvertToTrack(TrackDTO t)
        {
            return new Track()
            {
                TrackId = t.TrackId,
                EstablishmentId = t.EstablishmentId,
                Destination_Source = t.Destination_Source,
                Ingathering_Interspersion = t.Ingathering_Interspersion,
                FrequencyId = t.FrequencyId,
                TrackPrice = t.TrackPrice
            };
        }
        public static List<Track> ConvertToTrackList(List<TrackDTO> tl)
        {
            var TrackList = from t in tl
                               select new Track()
                               {
                                   TrackId = t.TrackId,
                                   EstablishmentId = t.EstablishmentId,
                                   Destination_Source = t.Destination_Source,
                                   Ingathering_Interspersion = t.Ingathering_Interspersion,
                                   FrequencyId = t.FrequencyId,
                                   TrackPrice = t.TrackPrice
                               };
            return TrackList.ToList();
        }
    }
}
