using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ViewModel;
using MongoDB.Driver;
using AutoMapper;

namespace BL
{
    public class OrganizationService
    {
        private readonly IMongoCollection<Organinzation> establishments;
        private readonly IMapper mapper;
        public OrganizationService(IDatabaseSettings settings, IMapper map)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            establishments = database.GetCollection<Organinzation>(this.GetType().Name);

            mapper = map;
        }
            public  List<OrganizationDTO> GetAllOrganizationsList()
            {
                return mapper.Map<List<OrganizationDTO>>(establishments.Find(_=>true).ToList());
            }

            public  OrganizationDTO GetEstablishmentByName(string name)
            {
                return mapper.Map<OrganizationDTO>(establishments.Find(e=>e.EstablishmentName==name).ToList().FirstOrDefault());
            }

            public  void AddEstablishmentToList(OrganizationDTO establishment)
            {
                establishments.InsertOne(mapper.Map<Organinzation>(establishment));
            }

            public  void PutEstablishment(OrganizationDTO establishment)
            {
                establishments.ReplaceOne(e => e.OrganizationId == establishment.EstablishmentId, mapper.Map<Organinzation>(establishment));
            }

            public  void DeleteEstablishment(string id)
            {
                establishments.DeleteOne(e => e.OrganizationId == id);
            }
        }
    }




