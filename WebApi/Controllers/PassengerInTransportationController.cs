using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

using BL;
using ViewModel;

namespace WebApi.Controllers
{
    public class PassengerInTransportationController : ControllerBase
    {
        private readonly PassengerInTrasportationService passengerInTrasportationService;
        public PassengerInTransportationController(PassengerInTrasportationService passengerInTrasportationService)
        {
            this.passengerInTrasportationService = passengerInTrasportationService;
        }
        [HttpGet("[action]")]
        // GET: api/PassengerInTransportation
        public IActionResult GetAllPassengersInTransportation()
        {
            return Ok(passengerInTrasportationService.GetAllPassengerInTransportationList());
        }

        // GET: api/PassengerInTransportation/5
        [HttpGet("[action]")]
        public IActionResult GetPassengerInTransportationById(string id)
        {
            return Ok(passengerInTrasportationService.GetPassengerInTransportationByPassengerId(id));
        }

        // POST: api/PassengerInTransportation
        [HttpPost("[action]")]
        public IActionResult AddPassengerInTransportation([FromBody]PassengerInTransportationDTO passengerInTransportation)
        {
            passengerInTrasportationService.AddPassengerInTransportationToList(passengerInTransportation);
            return Ok(passengerInTrasportationService.GetAllPassengerInTransportationList());
        }

        // PUT: api/PassengerInTransportation/5
        [HttpPut("[action]")]
        public IActionResult PutPassengerInTransportation([FromBody]PassengerInTransportationDTO passengerInTransportation)
        {
            passengerInTrasportationService.PutPassengerInTransportation(passengerInTransportation);
            return Ok(passengerInTrasportationService.GetAllPassengerInTransportationList());
        }

        // DELETE: api/PassengerInTransportation/5
        [HttpDelete("[action]")]
        public IActionResult DeletePassengerInTransportation(string id)
        {
            passengerInTrasportationService.DeletePassengerInTransportation(id);
            return Ok(passengerInTrasportationService.GetAllPassengerInTransportationList());
        }
    }
}
