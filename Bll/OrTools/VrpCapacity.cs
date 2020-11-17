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

namespace BL.OrTools
{
    
    public class VrpCapacity
    {


        private readonly TransportationService transportationService;
        public long[,] distanceMatrix(List<string> address)
        {
            DistanceMatrixRequest request = new DistanceMatrixRequest();
            
            request.Destinations = address.Select(t => new Location(t));
            request.Origins = address.Select(t => new Location(t));

            request.TravelMode = TravelMode.Driving;
            request.Key = "AIzaSyAXS8o9R2xBXjDX-_7SGv3xqE8ET_413wg";
            var res = GoogleMaps.DistanceMatrix.Query(request);

            //if (res.Status == Status.Ok)
            //{
                long[,] distanceMatrix=new long[address.Count(), address.Count()];
                for (int j=0; j < res.Rows.Count(); j++)
                {
                    Row row = res.Rows.ElementAt(j);
                    for (int i = 0; i < row.Elements.Count(); i++)
                    {
                        distanceMatrix[j,i] = Convert.ToInt64(row.Elements.ElementAt(i).Distance.Value);
                    }
                }
                return distanceMatrix;
            //}
            //throw Exception;
            //return res;

        }
        void callback(DistanceMatrixResponse response, string status)
        {
            if (response.Status == Status.Ok)
            {
                var origins = response.OriginAddresses.ToList();
                var destinations = response.DestinationAddresses.ToList();
                var rows = response.Rows.ToList();
                for (var i = 0; i < origins.Count(); i++)
                {
                    var results = rows[i].Elements.ToList();
                    for (var j = 0; j < results.Count(); j++)
                    {
                        var element = results[j];
                        var distance = element.Distance.Text;
                        var duration = element.Duration.Text;
                        var from = origins[i];
                        var to = destinations[j];
                    }
                }
            }
        }

        private readonly VehiclesService VehiclesService;
        public VrpCapacity(VehiclesService vehiclesService)
        {
            VehiclesService = vehiclesService;

        }
        /// <summary>
        ///   Print the solution.
        /// </summary>
        public string PrintSolution(
           in DataModel data,
           in RoutingModel routing,
           in RoutingIndexManager manager,
           in Assignment solution, string[] address)
        {
            string res = string.Empty;
            // Inspect solution.
            long totalDistance = 0;
            long totalLoad = 0;
            for (int i = 0; i < data.VehicleNumber; ++i)
            {
                res+=string.Format("/nRoute for Vehicle {0}: seats:{1}", i, data.VehicleCapacities[i]);
                long routeDistance = 0;
                long routeLoad = 0;
                var index = routing.Start(i);
                while (routing.IsEnd(index) == false)
                {
                    long nodeIndex = manager.IndexToNode(index);
                    routeLoad += data.Demands[nodeIndex];
                    res+=string.Format("/nAddress: {0}; {1} Load({2}) ->  ",address[nodeIndex], nodeIndex, routeLoad);
                    var previousIndex = index;
                    index = solution.Value(routing.NextVar(index));
                    routeDistance += routing.GetArcCostForVehicle(previousIndex, index, 0);
                }
                res+=string.Format("/n{0}", manager.IndexToNode((int)index));
                res+=string.Format("/nDistance of the route: {0}m", routeDistance);
                totalDistance += routeDistance;
                totalLoad += routeLoad;
            }
            res+=string.Format("/nTotal distance of all routes: {0}m", totalDistance);
            res+=string.Format("/nTotal load of all routes: {0}m", totalLoad);
            return res;
        }
        public string CalcRoute(DataModel data, string[] address)
        {
            // Instantiate the data problem.
            
            // Create Routing Index Manager
            RoutingIndexManager manager = new RoutingIndexManager(
                data.DistanceMatrix.GetLength(0),
               data.VehicleNumber,//50,// vehiclesService.GetAllVehiclesList().Count,
                new int[] { 0, 0, 0 },
                new int[] { 1, 2, 3});

            // Create Routing Model.
            RoutingModel routing = new RoutingModel(manager);

            // Create and register a transit callback.
            int transitCallbackIndex = routing.RegisterTransitCallback(
              (long fromIndex, long toIndex) =>
              {
                  // Convert from routing variable Index to distance matrix NodeIndex.
                  var fromNode = manager.IndexToNode(fromIndex);
                  var toNode = manager.IndexToNode(toIndex);
                  return data.DistanceMatrix[fromNode, toNode];
              }
            );

            // Define cost of each arc.
            routing.SetArcCostEvaluatorOfAllVehicles(transitCallbackIndex);

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
              false,                      // start cumul to zero
              "Capacity");

            // Setting first solution heuristic.
            RoutingSearchParameters searchParameters =
              operations_research_constraint_solver.DefaultRoutingSearchParameters();
            searchParameters.FirstSolutionStrategy =
              FirstSolutionStrategy.Types.Value.PathCheapestArc;

            // Solve the problem.
            Assignment solution = routing.SolveWithParameters(searchParameters);

            // Print solution on console.
            return PrintSolution(data, routing, manager, solution, address);
        }
    }
}
