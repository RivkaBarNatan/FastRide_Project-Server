using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using DAL;
using ViewModel;
using AutoMapper;
using System.Linq;

namespace BL
{
    public class RoutesService
    {
        private readonly IMongoCollection<Routes> routes;
        private readonly IMapper mapper;
        public RoutesService(IDatabaseSettings settings, IMapper map)
        {

            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            routes = database.GetCollection<Routes>(this.GetType().Name);

            mapper = map;
        }
        public List<RoutesDTO> GetAllRoutesList()
        {
            return mapper.Map<List<RoutesDTO>>(routes.Find(_ => true).ToList());
        }

        public RoutesDTO GetRouteById(string id)
        {
            return mapper.Map<RoutesDTO>(routes.Find(r => r.RouteId == id).ToList().FirstOrDefault());
        }

        public void AddRouteToList(RoutesDTO route)
        {
            routes.InsertOne(mapper.Map<Routes>(route));
        }

        public void PutRoute(RoutesDTO route)
        {
            routes.ReplaceOne(r => r.RouteId == route.RouteId, mapper.Map<Routes>(route));
        }

        public void DeleteRoute(string id)
        {
            routes.DeleteOne(r => r.RouteId == id);
        }
    }
}
