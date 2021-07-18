using System;
using System.Collections.Generic;
using Google.OrTools.ConstraintSolver;
using DAL;
using BL;
using ViewModel;
using GoogleApi;
using GoogleApi.Entities.Maps.DistanceMatrix.Request;
using GoogleApi.Entities.Maps.DistanceMatrix.Response;
using System.Linq;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Common.Enums;
using Google.Protobuf.WellKnownTypes;

namespace BL.OrTools
{
    
    public class VrpCapacity
    {

        //Class for return matrix of distance and route duration
        public class DistanceDuration
        {
            public long distance { get; set; }
            public long duration { get; set; }
        }
        public DistanceDuration[,] distanceMatrix(List<string> address)
        {
            DistanceMatrixRequest request = new DistanceMatrixRequest();
            request.Destinations = address.Select(t => new Location(t));
            request.Origins = address.Select(t => new Location(t));

            request.TravelMode = TravelMode.Driving;
            request.Key = "AIzaSyAXS8o9R2xBXjDX-_7SGv3xqE8ET_413wg";
            var res = GoogleMaps.DistanceMatrix.Query(request);

            DistanceDuration[,] distanceMatrix = new DistanceDuration[address.Count(), address.Count()];
            for (int j=0; j < res.Rows.Count(); j++)
            {
                Row row = res.Rows.ElementAt(j);
                for (int i = 0; i < row.Elements.Count(); i++)
                {
                    distanceMatrix[j, i] = new DistanceDuration();
                    distanceMatrix[j,i].duration = Convert.ToInt64(row.Elements.ElementAt(i).Duration.Value);
                    distanceMatrix[j,i].distance = Convert.ToInt64(row.Elements.ElementAt(i).Distance.Value);
                }
            }
            return distanceMatrix;

        }
        

        private readonly VehiclesService VehiclesService;
        public VrpCapacity(VehiclesService vehiclesService)
        {
            VehiclesService = vehiclesService;

        }

        //Class that contain the station address and the travel duration from the previous station
        //for calculate the estimated time the transportaion will arrive to this station.
        public class StationInfo
        {
            public string address { get; set; }
            public long timeFromPrevious { get; set; }
        }

        //Class for return order matrix and route duration
        public class ToReturn
        {
            public List<List<StationInfo>> way { get; set; }
            public List<DistanceDuration> timeDis { get; set; }
            public List<long> price { get; set; }
            public List<string> vehicleId { get; set; }
        }
        /// <summary>
        ///   Print the solution.
        /// </summary>
        public ToReturn PrintSolution(
           in DataModel data,
           in RoutingModel routing,
           in RoutingIndexManager manager,
           in Assignment solution, string[] address)
        {
            //address matrix per vehicle
            List<List<StationInfo>> waypoint=new List<List<StationInfo>>(data.VehicleNumber) { null };
            waypoint[0] = new List<StationInfo>() { null };
            ToReturn ret=new ToReturn();
            ret.timeDis= new List<DistanceDuration>();
            ret.price = new List<long>();
            ret.vehicleId = new List<string>();
            string driverAdderss="";

            string res = string.Empty;
            // Inspect solution.
            long totalDistance = 0;
            long totalLoad = 0;



            for (int i = 0; i < data.VehicleNumber; ++i)
            {
                int j = 0;
                res +=string.Format("/nRoute for Vehicle {0}: seats:{1}", i, data.VehicleCapacities[i]);
                DistanceDuration routeDistance = new DistanceDuration();
                long routeLoad = 0;
                var index = routing.Start(i);
                while (routing.IsEnd(index) == false)
                {
                    long nodeIndex = manager.IndexToNode(index);
                    routeLoad += data.Demands[nodeIndex];
                    res += string.Format("/nAddress: {0}; {1} Load({2}) ->  Distance from previous station: {3}", address[nodeIndex], nodeIndex, routeLoad, routing.GetArcCostForVehicle(index, solution.Value(routing.NextVar(index)), 0));
                    if (j > 0)
                    {
                        if (routing.IsEnd(solution.Value(routing.NextVar(index))) == true && i + 1 < data.VehicleNumber)
                        {
                            waypoint.Add(new List<StationInfo>() { null });
                        }
                        StationInfo info = new StationInfo()
                        {
                            address = address[nodeIndex],
                            timeFromPrevious = routing.GetArcCostForVehicle(index, solution.Value(routing.NextVar(index)), 0)
                        };
                        waypoint[i].Add(info);
                    }
                    else
                    {
                        if (routing.IsEnd(solution.Value(routing.NextVar(index)))==true && i+1 < data.VehicleNumber)
                        {
                            
                            waypoint.Add(new List<StationInfo>() { null });
                            StationInfo info = new StationInfo()
                            {
                                address = address[nodeIndex],
                                timeFromPrevious = routing.GetArcCostForVehicle(index, solution.Value(routing.NextVar(index)), 0)
                            };
                            waypoint[i][0] = info;
                        }
                        else
                        {
                            StationInfo info = new StationInfo() 
                            { address= address[nodeIndex],
                              timeFromPrevious = routing.GetArcCostForVehicle(index, solution.Value(routing.NextVar(index)), 0)
                            };
                            waypoint[i][j]=info;
                        }
                    }
                    var previousIndex = index;
                    index = solution.Value(routing.NextVar(index));
                    routeDistance.distance += data.DistanceMatrix[nodeIndex, previousIndex].distance;

                    //routeDistance.distance += routing.GetArcCostForVehicle(previousIndex, index, 0);
                    routeDistance.duration += routing.GetArcCostForVehicle(previousIndex, index, 0);
                    j++;
                    driverAdderss = address[nodeIndex];
                }
                res+=string.Format("/n{0}", manager.IndexToNode((int)index));
                res+=string.Format("/nDistance of the route: {0}m, Time of the route: {1}", routeDistance.distance, routeDistance.duration/60);
                if(routeDistance.duration!=0)
                {
                    ret.timeDis.Add(new DistanceDuration()
                    {
                        duration = routeDistance.duration / 60,
                        distance = routeDistance.distance
                    });
                    // calculate the price of the route
                    ret.price.Add((long)(VehiclesService.GetVehicleByAddressAndCapacity(address[i+1], data.VehicleCapacities[i]).PriceForKM * routeDistance.distance/1000));
                    ret.vehicleId.Add(VehiclesService.GetVehicleByAddressAndCapacity(address[i + 1], data.VehicleCapacities[i]).VehiclesId);
                    var updateVehicle = VehiclesService.GetVehicleByAddressAndCapacity(address[i + 1], data.VehicleCapacities[i]);
                    updateVehicle.DriverAddress = driverAdderss;
                    //VehiclesService.PutVehicles(updateVehicle);
                }
                totalDistance += routeDistance.distance;
                totalLoad += routeLoad;
            }
            res+=string.Format("/nTotal distance of all routes: {0}m", totalDistance);
            res+=string.Format("/nTotal load of all routes: {0}m", totalLoad);
            Console.WriteLine(res); 
            ret.way = waypoint;
            return ret;
        }
        public ToReturn CalcRoute(DataModel data, string[] address)
        {
            // Instantiate the data problem.
            
            // Create Routing Index Manager
            RoutingIndexManager manager = new RoutingIndexManager(
                data.DistanceMatrix.GetLength(0),
               data.VehicleNumber,
               data.start,
               data.end);
            

            // Create Routing Model.
            RoutingModel routing = new RoutingModel(manager);

            // Create and register a transit callback.
            int transitCallbackIndex = routing.RegisterTransitCallback(
              (long fromIndex, long toIndex) =>
              {
                  // Convert from routing variable Index to distance matrix NodeIndex.
                  var fromNode = manager.IndexToNode(fromIndex);
                  var toNode = manager.IndexToNode(toIndex);
                  return data.DistanceMatrix[fromNode, toNode].duration;
              }
            );

            // Define cost of each arc.
            try
            { 
                if (data.VehicleNumber == 0)
                    return null;
                routing.SetArcCostEvaluatorOfAllVehicles(transitCallbackIndex);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            // Add Capacity constraint.
            int demandCallbackIndex = routing.RegisterUnaryTransitCallback(
              (long fromIndex) =>
              {
                  // Convert from routing variable Index to demand NodeIndex.
                  var fromNode = manager.IndexToNode(fromIndex);
                  return data.Demands[fromNode];
              }
            );
            routing.AddDimensionWithVehicleCapacity(
              demandCallbackIndex, 0,  // null capacity slack
              data.VehicleCapacities,   // vehicle maximum capacities
              true,                      // start cumul to zero
              "Duration");


            // Setting first solution heuristic.
            RoutingSearchParameters searchParameters =
              operations_research_constraint_solver.DefaultRoutingSearchParameters();
            searchParameters.FirstSolutionStrategy =
              FirstSolutionStrategy.Types.Value.PathCheapestArc;
            searchParameters.LocalSearchMetaheuristic = LocalSearchMetaheuristic.Types.Value.GuidedLocalSearch;
            searchParameters.TimeLimit = new Duration { Seconds = 1 };

            // Solve the problem.
            Assignment solution = routing.SolveWithParameters(searchParameters);

            // Print solution on console.
            return PrintSolution(data, routing, manager, solution, address);
        }
    }   
}
