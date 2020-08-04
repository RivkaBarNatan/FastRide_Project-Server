using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using BL;
using ViewModel;


namespace WebApi.Controllers
{

    public class ChildInFamilyController : ControllerBase
    {
        private readonly ChildInFamilyService childInFamilyService;
        public ChildInFamilyController(ChildInFamilyService childInFamilyService)
        {
            this.childInFamilyService = childInFamilyService;
        }
        [HttpGet("[action]")]
        // GET: api/ChildInFamily
        public IActionResult GetAllChildForFamily()
        {
            return Ok(childInFamilyService.GetAllChildInFamilyList());
        }

        [HttpGet("[action]")]
        // GET: api/ChildInFamily/5
        public IActionResult GetChildInFamilyByName(string name)
        {
            return Ok(childInFamilyService.GetChildInFamilyByName(name));
        }
        [HttpPost("[action]")]
        // POST: api/ChildInFamily
        public IActionResult AddChildInFamily([FromBody]ChildInFamilyDTO childInFamily)
        {
            childInFamilyService.AddChildInFamilyToList(childInFamily);
            return Ok(childInFamilyService.GetAllChildInFamilyList());
        }
        [HttpPut("[action]")]
        // PUT: api/ChildInFamily/5
        public IActionResult PutChildInFamily([FromBody]ChildInFamilyDTO childInFamily)
        {
            childInFamilyService.PutChildInFamily(childInFamily);
            return Ok(childInFamilyService.GetAllChildInFamilyList());
        }

        [HttpDelete("[action]")]
        // DELETE: api/ChildInFamily/5
        public IActionResult DeleteChildInFamily(string id)
        {
            childInFamilyService.DeleteChildInFamily(id);
            return Ok(childInFamilyService.GetAllChildInFamilyList());
        }
    }
}
