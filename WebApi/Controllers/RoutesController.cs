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
    public class RoutesController : ControllerBase
    {
        private readonly RoutesService routesService;
        public RoutesController(RoutesService routesService)
        {
            this.routesService = routesService;
        }

        // GET: api/<RoutesController>
        [HttpGet("[action]")]
        public IActionResult GetAllRoutesList()
        {
            return Ok(routesService.GetAllRoutesList());
        }

        // GET api/<RoutesController>/5
        [HttpGet("[action]")]
        public IActionResult GetRouteById(string id)
        {
            return Ok(routesService.GetRouteById(id));
        }

        // POST api/<RoutesController>
        [HttpPost("[action]")]
        public IActionResult AddRoute([FromBody] RoutesDTO route)
        {
            routesService.AddRouteToList(route);
            return Ok(this.GetAllRoutesList());
        }

        // PUT api/<RoutesController>/5
        [HttpPut("[action]")]
        public IActionResult PutRoute([FromBody] RoutesDTO route)
        {
            routesService.PutRoute(route);
            return Ok(this.GetAllRoutesList());
        }

        // DELETE api/<RoutesController>/5
        [HttpDelete("[action]")]
        public IActionResult DeleteRoute(string id)
        {
            routesService.DeleteRoute(id);
            return Ok(this.GetAllRoutesList());
        }
    }
}
