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
    public class PassengerInStationController : ControllerBase
    {
        private readonly PassengerInStationService passengerInStationService;
        public PassengerInStationController(PassengerInStationService passengerInStationService)
        {
            this.passengerInStationService = passengerInStationService;
        }
        [HttpGet("[action]")]
        // GET: api/PassengerInStation
        public IActionResult GetAllPassengerInStation()
        {
            return Ok(passengerInStationService.GetAllPassengerInStationList());
        }

        [HttpGet("[action]")]
        // GET: api/PassengerInStation/5
        public IActionResult GetPassengerInStationById(string id)
        {
            return Ok(passengerInStationService.GetPassengerInStationById(id));
        }

        [HttpPost("[action]")]
        // POST: api/PassengerInStation
        public IActionResult AddPassengerInStation([FromBody]PassengerInStationDTO passengerInStation)
        {
            passengerInStationService.AddPassengerInStationToList(passengerInStation);
            return Ok(passengerInStationService.GetAllPassengerInStationList());
        }

        [HttpPut("[action]")]
        // PUT: api/PassengerInStation/5
        public IActionResult PutPassengerInStation([FromBody]PassengerInStationDTO passengerInStation)
        {
            passengerInStationService.PutPassengerInStation(passengerInStation);
            return Ok(passengerInStationService.GetAllPassengerInStationList());
        }

        [HttpDelete("[action]")]
        // DELETE: api/PassengerInStation/5
        public IActionResult DeletePassengerInStation(string id)
        {
            passengerInStationService.DeletePassengerInStation(id);
            return Ok(passengerInStationService.GetAllPassengerInStationList());
        }
    }
}
