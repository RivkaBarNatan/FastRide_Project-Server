using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;    
using System.Net;     
using System.Net.Http;
using BL;
using ViewModel;
using BL.OrTools;
using AutoMapper;

namespace WebApi.Controllers
{
    public class TransportationController : ControllerBase
    {
        private readonly TransportationService transportationService;
        private readonly VrpCapacity vrpCapcity;
        public TransportationController(TransportationService transportationService, VrpCapacity vrpCapcity)
        {
            this.transportationService = transportationService;
            this.vrpCapcity = vrpCapcity;
        }
        [HttpGet("[action]")]        // GET: api/Transportation
        public IActionResult GetAllTransportation()
        {
            return Ok(transportationService.GetAllTransportationsList());
        }

        [HttpGet("[action]")]        // GET: api/Transportation/5
        public IActionResult GetTransportationById(string id)
        {
            return Ok(transportationService.GetTransportationsById(id));
        }

        [HttpPost("[action]")]        // POST: api/Transportation
        public IActionResult AddTransportation([FromBody] TransportationDTO transportation)
        {
            transportationService.AddTransportationsToList(transportation);
            return Ok(transportationService.GetAllTransportationsList());
        }

        [HttpPut("[action]")]        // PUT: api/Transportation/5
        public IActionResult PutTransportation([FromBody] TransportationDTO transportation)
        {
            transportationService.PutTransportations(transportation);
            return Ok(transportationService.GetAllTransportationsList());
        }

        [HttpDelete("[action]")]        // DELETE: api/Transportation/5
        public IActionResult DeleteTransportation(string id)
        {
            transportationService.DeleteTransportations(id);
            return Ok(transportationService.GetAllTransportationsList());
        }

        [HttpGet("[action]")]
        public IActionResult CalcRoute(string transportationId)
        {
            return Ok(transportationService.CalcRoute(transportationId));
        }

        [HttpGet("[action]")]
        //For get a route with station union
        public IActionResult StationUnion(string transportationId, [FromQuery]  List<string> route,  long[] distances)
        {
            return Ok(transportationService.StationUnion(route, distances, transportationId));
        }
    }
}
