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
    public class StationController : ControllerBase
    {
        private readonly StationService stationService;
        public StationController(StationService stationService)
        {
            this.stationService = stationService;
        }
        [HttpGet("[action]")]        // GET: api/Station
        public IActionResult GetAllStation()
        {
            return Ok(stationService.GetAllStationsList());
        }

        [HttpGet("[action]")]
        // GET: api/Station/5
        public IActionResult GetStationById(string id)
        {
            return Ok(stationService.GetStationsById(id));
        }

        [HttpPost("[action]")]
        // POST: api/Station
        public IActionResult AddStation([FromBody]StationDTO station)
        {
            stationService.AddStationToList(station);
            return Ok(stationService.GetAllStationsList());
        }

        [HttpPut("[action]")]
        // PUT: api/Station/5
        public IActionResult PutStation([FromBody]StationDTO station)
        {
            stationService.PutStations(station);
            return Ok(stationService.GetAllStationsList());
        }

        [HttpDelete("[action]")]
        // DELETE: api/Station/5
        public IActionResult DeleteStation(string id)
        {
            stationService.DeleteStations(id);
            return Ok(stationService.GetAllStationsList());
        }
    }
}
