//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Dal;
//using ViewModel;
//using MongoDB.Driver;

//namespace BL
//{
//    public class PassengerInTrasportationService
//    {
//        private readonly IMongoCollection<PassengerInTransportation> passengerInTransportation;
//        public PassengerInTrasportationService(IDatabaseSettings settings)
//        {
//            var client = new MongoClient(settings.ConnectionString);
//            var database = client.GetDatabase(settings.DatabaseName);
//            passengerInTransportation = database.GetCollection<PassengerInTransportation>(this.GetType().Name);
//        }
//        public  List<PassengerInTransportationDTO> GetAllPassengerInTransportationList()
//        {
//            return PassengerInTransportationDTO.ConvertToPassengerInTransportationDTOList(passengerInTransportation.Find(_ => true).ToList());
//        }

//        public  PassengerInTransportationDTO GetPassengerInTransportationByPassengerId(string id)
//        {
//            return PassengerInTransportationDTO.ConvertToPassengerInTransportationDTO(passengerInTransportation.Find(p => p.PassengerInTransportationId == id).ToList().FirstOrDefault());
//        }

//        public  void AddPassengerInTransportationToList(PassengerInTransportationDTO passengerInTransportation)
//        {
//            this.passengerInTransportation.InsertOne(PassengerInTransportationDTO.ConvertToPassengerInTransportation(passengerInTransportation));
//            //TODO TE.SaveChanges();
//        }

//        public  void PutPassengerInTransportation(PassengerInTransportationDTO passengerInTrans)
//        {
//            //PassengerInTransportation passengerInTransportation = TE.PassengerInTransportation.Where(p => p.PassengerInTransportationId.Equals(passengerInTrans.PassengerInTransportationId)).FirstOrDefault();
//            //passengerInTransportation.TransportationId = passengerInTrans.TransportationId;
//            //passengerInTransportation.PassengerId = passengerInTrans.PassengerId;
            
//            var update = Builders<PassengerInTransportation>.Update.Set(p => p.PassengerInTransportationId, passengerInTrans.PassengerInTransportationId);
//            passengerInTransportation.UpdateOne(p => p.PassengerInTransportationId == passengerInTrans.PassengerInTransportationId, update);
//            update.Set(p => p.PassengerId, passengerInTrans.PassengerId);
//            passengerInTransportation.UpdateOne(p => p.PassengerInTransportationId == passengerInTrans.PassengerInTransportationId, update);
//            //TODO TE.SaveChanges();
//        }

//        public  void DeletePassengerInTransportation(string id)
//        {
//            passengerInTransportation.DeleteOne(p => p.PassengerInTransportationId == id);
           
//        }
//        public string[] GetAddressList(string transportationId)
//        {
//            var PassengerIdList = from x in GetAllPassengerInTransportationList()
//                                  where x.TransportationId == transportationId
//                                  select x.PassengerId;
//            var AddressList = from x in PassengerIdList
//                                 select ChildInFamilyService.GetFamilyByChildId(x).Address;
//            return AddressList.ToArray();
//        }
//    }
//}
