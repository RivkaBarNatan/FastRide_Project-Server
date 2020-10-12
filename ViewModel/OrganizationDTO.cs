using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using MongoDB.Bson.Serialization.Attributes;

namespace ViewModel
{
    public class OrganizationDTO
    {
        [BsonId]
        public string EstablishmentId { get; set; }
        public string Address { get; set; }
        public string EstablishmentName { get; set; }
        public string CelContactMan { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
