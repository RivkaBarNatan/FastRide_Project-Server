using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BL.OrTools
{
    public class DataModel
    {
        public VrpCapacity.DistanceDuration[,] DistanceMatrix { get; set; }
        public long[] Demands { get; set; }
        public long[] VehicleCapacities { get; set; }
        public int VehicleNumber { get; set; }
        public int Depot { get; set; }
        public int[] start { get; set; }
        public int[] end { get; set; }

    };
}
