using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using Dal;

namespace UI
{
    public class StationFunction
    {
        
        static TransportationDBEntities TE = new TransportationDBEntities();
        public static List<StationDTO> GetAllStationsList()
        {
            return StationDTO.ConvertToStationsDTOList(TE.Station.ToList());
        }

        public static StationDTO GetStationsById(int id)
        {
            Station stations = TE.Station.Where(s => s.StationId.Equals(id)).FirstOrDefault();
            return StationDTO.ConvertToStationsDTO(stations);
        }

        public static void AddStationToList(StationDTO stations)
        {
            TE.Station.Add(StationDTO.ConvertToStations(stations));
            //TODO TE.SaveChanges();
        }

        public static void PutStations(StationDTO station)
        {
            Station stations = TE.Station.Where(s => s.StationId.Equals(station.StationId)).FirstOrDefault();
            stations.Address = station.Address;
            //TODO TE.SaveChanges();
        }

        public static void DeleteStations(int id)
        {
            Station stations = TE.Station.Where(s => s.StationId.Equals(id)).FirstOrDefault();
            TE.Station.Remove(stations);
            //TODO TE.SaveChanges();
        }
    }
}


