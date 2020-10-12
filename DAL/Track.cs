using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace DAL
{

    public partial class Track
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string TrackId { get; set; }
        public string EstablishmentId { get; set; }
        public string Destination_Source { get; set; }
        public string Ingathering_Interspersion { get; set; }
        public string FrequencyId { get; set; }
        public Nullable<int> TrackPrice { get; set; }

        public List<Station> Stations { get; set; }
    }
}
