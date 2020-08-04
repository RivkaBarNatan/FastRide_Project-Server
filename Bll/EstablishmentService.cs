using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using ViewModel;
using MongoDB.Driver;

namespace BL
{
    public class EstablishmentService
    {
        private readonly IMongoCollection<Establishments> establishments;
        public EstablishmentService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            establishments = database.GetCollection<Establishments>(this.GetType().Name);
        }
            public  List<EstablishmentDTO> GetAllEstablishmentList()
            {
                return EstablishmentDTO.ConvertToEstablishmentDTOList(establishments.Find(_=>true).ToList());
            }

            public  EstablishmentDTO GetEstablishmentByName(string name)
            {
                return EstablishmentDTO.ConvertToEstablishmentDTO(establishments.Find(e=>e.EstablishmentName==name).ToList().FirstOrDefault());
            }

            public  void AddEstablishmentToList(EstablishmentDTO establishment)
            {
                establishments.InsertOne(EstablishmentDTO.ConvertToEstablishment(establishment));
                //TODO TE.SaveChanges();
            }

            public  void PutEstablishment(EstablishmentDTO establishment)
            {
            establishments.ReplaceOne(e => e.EstablishmentId == establishment.EstablishmentId, EstablishmentDTO.ConvertToEstablishment(establishment));

                //TODO TE.SaveChanges();
            }

            public  void DeleteEstablishment(string id)
            {
            establishments.DeleteOne(e => e.EstablishmentId == id);
                //TODO TE.SaveChanges();
            }
        }
    }




