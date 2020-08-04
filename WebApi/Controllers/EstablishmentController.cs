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
    public class EstablishmentController : ControllerBase
    {
        private readonly EstablishmentService establishmentService;
        public EstablishmentController(EstablishmentService establishmentService)
        {
            this.establishmentService = establishmentService;
        }
        [HttpGet("[action]")]
        // GET: api/Establishment
        public IActionResult GetAllEstablishmentList()
        {
            return Ok(establishmentService.GetAllEstablishmentList());
        }

        [HttpGet("[action]")]
        // GET: api/Establishment/5
        public IActionResult GetEstablishmentByName(string name)
        {
            return Ok(establishmentService.GetEstablishmentByName(name));
        }

        [HttpPost("[action]")]
        // POST: api/Establishment
        public IActionResult AddEstablishment([FromBody]EstablishmentDTO establishment)
        {
            establishmentService.AddEstablishmentToList(establishment);
            return Ok(establishmentService.GetAllEstablishmentList());
        }

        [HttpPut("[action]")]
        // PUT: api/Establishment/5
        public IActionResult PutEstablishment([FromBody]EstablishmentDTO establishment)
        {
            establishmentService.PutEstablishment(establishment);
            return Ok(establishmentService.GetAllEstablishmentList());

        }

        [HttpDelete("[action]")]        // DELETE: api/Establishment/5
        public IActionResult DeleteEstablishment(string id)
        {
            establishmentService.DeleteEstablishment(id);
            return Ok(establishmentService.GetAllEstablishmentList());
        }

    }
}
