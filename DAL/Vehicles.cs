
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>


namespace DAL
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using System;
    using System.Collections.Generic;
    
    public partial class Vehicles
    {
        public Vehicles()
        {
        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string VehiclesId { get; set; }
        public string TypeVhicles { get; set; }
        public Nullable<int> AmountPlaces { get; set; }
        public Nullable<int> PriceForKM { get; set; }
        public string DriverAddress { get; set; }
    }
}
