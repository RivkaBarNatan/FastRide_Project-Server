using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public enum userType
    {
        group, unit
    }
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public List<string> Address { get; set; }
        public string Email { get; set; }
        public userType Type { get; set; }
        public List<string> TransportationCreated { get; set; }
        public string OrganizatioId { get; set; }
        
    }

}
