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
    public class TrackController : ControllerBase
    {
        private readonly TrackService trackService;
        public TrackController(TrackService trackService)
        {
            this.trackService = trackService;
        }
        [HttpGet("[action]")]        // GET: api/Track
        public IActionResult GetAllTracks()
        {
            return Ok(trackService.GetAllTrackList());
        }

        [HttpGet("[action]")]        // GET: api/Track/5
        public IActionResult GetTrackByEstablishmentId(string id)
        {
            return Ok(trackService.GetTrackByEstablishmentId(id));
        }

        [HttpPost("[action]")]        // POST: api/Track
        public IActionResult AddTrack([FromBody]TrackDTO track)
        {
            trackService.AddTrackToList(track);
            return Ok(trackService.GetAllTrackList());
        }

        [HttpPut("[action]")]        // PUT: api/Track/5
        public IActionResult PutTrack([FromBody]TrackDTO track)
        {
            trackService.PutTrack(track);
            return Ok(trackService.GetAllTrackList());
        }

        [HttpDelete("[action]")]        // DELETE: api/Track/5
        public IActionResult DeleteTrack(string id)
        {
            trackService.DeleteTrack(id);
            return Ok(trackService.GetAllTrackList());
        }
    }
}
