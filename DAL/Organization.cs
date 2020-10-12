using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace DAL
{
  
    public partial class Organinzation
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string OrganizationId { get; set; }
        public string Address { get; set; }
        public string EstablishmentName { get; set; }
        public string CelContactMan { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
