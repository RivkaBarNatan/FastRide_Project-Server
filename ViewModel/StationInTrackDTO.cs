using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using MongoDB.Bson.Serialization.Attributes;

namespace ViewModel
{
    public class StationInTrackDTO
    {
        [BsonId]
        public string StationInTrackId { get; set; }
        public string TrackId { get; set; }
        public string StationId { get; set; }
        public int OrdinalNumberInTrack { get; set; }

        public static StationInTrackDTO ConvertToStationInTrackDTO(StationInTrack s)
        {
            return new StationInTrackDTO()
            {
                StationInTrackId=s.StationInTrackId,
                TrackId=s.TrackId,
                StationId=s.StationId,
                OrdinalNumberInTrack=s.OrdinalNumberInTrack.Value

            };
        }
        public static List<StationInTrackDTO> ConvertToStationInTrackDTOList(List<StationInTrack> sl)
        {
            var DTOList = from s in sl
                          select new StationInTrackDTO()
                          {
                              StationInTrackId = s.StationInTrackId,
                              TrackId = s.TrackId,
                              StationId = s.StationId,
                              OrdinalNumberInTrack = s.OrdinalNumberInTrack.Value
                          };
            return DTOList.ToList();
        }
        public static StationInTrack ConvertToStationInTrack(StationInTrackDTO s)
        {
            return new StationInTrack()
            {
                StationInTrackId = s.StationInTrackId,
                TrackId = s.TrackId,
                StationId = s.StationId,
                OrdinalNumberInTrack = s.OrdinalNumberInTrack
            };
        }
        public static List<StationInTrack> ConvertToStationInTrackList(List<StationInTrackDTO> sl)
        {
            var ChildInFamilyList = from s in sl
                                    select new StationInTrack()
                                    {
                                        StationInTrackId = s.StationInTrackId,
                                        TrackId = s.TrackId,
                                        StationId = s.StationId,
                                        OrdinalNumberInTrack = s.OrdinalNumberInTrack
                                    };
            return ChildInFamilyList.ToList();
        }
    }
}
