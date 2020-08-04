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
    public class VehiclesController : ControllerBase
    {
        private readonly VehiclesService vehiclesService;
        public VehiclesController(VehiclesService vehiclesService)
        {
            this.vehiclesService = vehiclesService;
        }
        [HttpGet("[action]")]        // GET: api/Vehicles
        public IActionResult GetAllVehiclesList()
        {
            return Ok(vehiclesService.GetAllVehiclesList());
        }

        [HttpGet("[action]")]
        // GET: api/Vehicles/5
        public IActionResult GetVehiclesByType(string type)
        {
            return Ok(vehiclesService.GetVehiclesByType(type));
        }

        [HttpPost("[action]")]        // POST: api/Vehicles
        public IActionResult AddVehicles([FromBody]VehiclesDTO vehicles)
        {
            vehiclesService.AddVehiclesToList(vehicles);
            return Ok(vehiclesService.GetAllVehiclesList());
        }

        [HttpPut("[action]")]        // PUT: api/Vehicles/5
        public IActionResult PutVehicles([FromBody]VehiclesDTO vehicles)
        {
            vehiclesService.PutVehicles(vehicles);
            return Ok(vehiclesService.GetAllVehiclesList());
        }

        [HttpDelete("[action]")]        // DELETE: api/Vehicles/5
        public IActionResult DeleteVehicles(string id)
        {
            vehiclesService.DeleteVehicles(id);
            return Ok(vehiclesService.GetAllVehiclesList());
        }
    }
}
