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
    public class StationInTrackController : ControllerBase
    {
        private readonly StationInTrackService stationInTrackService;
        public StationInTrackController(StationInTrackService stationInTrackService)
        {
            this.stationInTrackService = stationInTrackService;
        }
        [HttpGet("[action]")]        // GET: api/StationInTrack
        public IActionResult GetAllStationInTrack()
        {
            return Ok(stationInTrackService.GetAllStationInTrackList());
        }

        [HttpGet("[action]")]        // GET: api/StationInTrack/5
        public IActionResult GetStationInTrackById(string id)
        {
            return Ok(stationInTrackService.GetStationInTrackById(id));
        }

        [HttpPost("[action]")]        // POST: api/StationInTrack
        public IActionResult AddStationInTrack([FromBody]StationInTrackDTO stationInTrack)
        {
            stationInTrackService.AddStationInTrackToList(stationInTrack);
            return Ok(stationInTrackService.GetAllStationInTrackList());
        }

        [HttpPut("[action]")]        // PUT: api/StationInTrack/5
        public IActionResult PutStationInTrack([FromBody]StationInTrackDTO stationInTrack)
        {
            stationInTrackService.PutStationInTrack(stationInTrack);
            return Ok(stationInTrackService.GetAllStationInTrackList());
        }

        [HttpDelete("[action]")]        // DELETE: api/StationInTrack/5
        public IActionResult DeleteStationInTrack(string id)
        {
            stationInTrackService.DeleteStationstationInTrack(id);
            return Ok(stationInTrackService.GetAllStationInTrackList());
        }
    }
}
