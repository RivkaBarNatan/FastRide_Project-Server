using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BL.OrTools
{
    public class DataModel
    {
        private readonly VrpCapacity vrpCapacity;
        private readonly TransportationService transportationService;
        private readonly VehiclesService vehiclesSer;
        public DataModel(string transportationId)
        {

            DistanceMatrix = vrpCapacity.distanceMatrix(
                transportationService.GetCountPassengerInStation(transportationId).Select(d=>d.Address).ToList(),
                transportationService.GetAllTransportationsList().Select(a=>a.Address).ToString());
            
            Demands = transportationService.GetCountPassengerInStation(transportationId).Select(c=>(long)c.Count).ToArray();
            VehicleCapacities = vehiclesSer.GetAllVehiclesCapacity();
            Depot = 0;
        }
        public long[,] DistanceMatrix { get; set; }
        public long[] Demands { get; set; }
        public long[] VehicleCapacities { get; set; }
        public int VehicleNumber { get; set; }
        public int Depot { get; set; }

    };
}
