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
    public class OrganizationController : ControllerBase
    {
        private readonly OrganizationService establishmentService;
        public OrganizationController(OrganizationService establishmentService)
        {
            this.establishmentService = establishmentService;
        }
        [HttpGet("[action]")]
        // GET: api/Establishment
        public IActionResult GetAllEstablishmentList()
        {
            return Ok(establishmentService.GetAllOrganizationsList());
        }

        [HttpGet("[action]")]
        // GET: api/Establishment/5
        public IActionResult GetEstablishmentByName(string name)
        {
            return Ok(establishmentService.GetEstablishmentByName(name));
        }

        [HttpPost("[action]")]
        // POST: api/Establishment
        public IActionResult AddEstablishment([FromBody]OrganizationDTO establishment)
        {
            establishmentService.AddEstablishmentToList(establishment);
            return Ok(establishmentService.GetAllOrganizationsList());
        }

        [HttpPut("[action]")]
        // PUT: api/Establishment/5
        public IActionResult PutEstablishment([FromBody]OrganizationDTO establishment)
        {
            establishmentService.PutEstablishment(establishment);
            return Ok(establishmentService.GetAllOrganizationsList());

        }

        [HttpDelete("[action]")]        // DELETE: api/Establishment/5
        public IActionResult DeleteEstablishment(string id)
        {
            establishmentService.DeleteEstablishment(id);
            return Ok(establishmentService.GetAllOrganizationsList());
        }

    }
}
