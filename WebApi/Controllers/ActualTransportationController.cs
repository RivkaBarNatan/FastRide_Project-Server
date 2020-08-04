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
    public class ActualTransportationController : ControllerBase
    {
        private readonly ActualTransportationService actualTransportationService;
        public ActualTransportationController(ActualTransportationService actualTransportationService)
        {
            this.actualTransportationService = actualTransportationService;
        }
        [HttpGet("[action]")]
        // GET: api/ActualTransportation
        public IActionResult GetAllActualTransportation()
        {
            return Ok(actualTransportationService.GetAllActualTransportationList());
        }

        [HttpGet("[action]")]
        // GET: api/ActualTransportation/5
        public IActionResult GetActualTransportationByTransportationId(string id)
        {
            return Ok(actualTransportationService.GetActualTransportationByTransportationId(id));
        }

        [HttpPost("[action]")]
        // POST: api/ActualTransportation
        public IActionResult AddActualTransportation([FromBody] ActualTransportationDTO ActualTransportation)
        {
            actualTransportationService.AddActualTransportationToList(ActualTransportation);
            return Ok(actualTransportationService.GetAllActualTransportationList());
        }

        [HttpPut("[action]")]
        // PUT: api/ActualTransportation/5
        public IActionResult PutActualTransportation([FromBody]ActualTransportationDTO ActualTransportation)
        {
            actualTransportationService.PutActualTransportation(ActualTransportation);
            return Ok(actualTransportationService.GetAllActualTransportationList());
        }

        [HttpDelete("[action]")]
        // DELETE: api/ActualTransportation/5
        public IActionResult DeleteActualTransportation(string id)
        {
            actualTransportationService.DeleteActualTransportation(id);
            return Ok(actualTransportationService.GetAllActualTransportationList());
        }
    }
}
