using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace DAL
{
   
    public partial class Frequency
    {
       
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string FrequencyId { get; set; }
        public string FrequencyType { get; set; }


    }
}
