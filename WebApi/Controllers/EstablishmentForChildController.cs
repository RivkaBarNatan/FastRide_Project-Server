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
    public class EstablishmentForChildController : ControllerBase
    {
        private readonly EstablishmentForChildService establishmentForChildService;
        public EstablishmentForChildController(EstablishmentForChildService establishmentForChildService)
        {
            this.establishmentForChildService = establishmentForChildService;
        }
        [HttpGet("[action]")]
        // GET: api/EstablishmentForChild
        public IActionResult GetAllEstablishmentForChild()
        {
            return Ok(establishmentForChildService.GetAllEstablishmentForChildList());
        }

        [HttpGet("[action]")]        
        // GET: api/EstablishmentForChild/5
        public IActionResult GetEstablishmentForChildByIdChild(string id)
        {
            return Ok(establishmentForChildService.GetEstablishmentForChildByIdChild(id));
        }

        [HttpPost("[action]")]        // POST: api/EstablishmentForChild
        public IActionResult AddEstablishmentForChild([FromBody]EstablishmentForChildDTO establishmentForChild)
        {
            establishmentForChildService.AddEstablishmentForChildToList(establishmentForChild);
            return Ok(establishmentForChildService.GetAllEstablishmentForChildList());
        }

        [HttpPut("[action]")]        // PUT: api/EstablishmentForChild/5
        public IActionResult PutEstablishmentForChild([FromBody]EstablishmentForChildDTO establishmentForChild)
        {
            establishmentForChildService.PutEstablishmentForChild(establishmentForChild);
            return Ok(establishmentForChildService.GetAllEstablishmentForChildList());
        }

        [HttpDelete("[action]")]
        // DELETE: api/EstablishmentForChild/5
        public IActionResult DeleteEstablishmentForChild(string id)
        {
            establishmentForChildService.DeleteEstablishmentForChild(id);
            return Ok(establishmentForChildService.GetAllEstablishmentForChildList());
        }
    }
}
