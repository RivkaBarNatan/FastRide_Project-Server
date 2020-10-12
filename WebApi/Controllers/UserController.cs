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
    public class UserController : ControllerBase
    {
        private readonly UserService familyService;
        public UserController(UserService familyService)
        {
            this.familyService = familyService;
        }
        [HttpGet("[action]")]   
        // GET: api/Family
        public IActionResult GetAllFamilyList()
        {
            return Ok(familyService.GetAllFamilyList());
        }

        [HttpGet("[action]")]
        // GET: api/Family/5
        public IActionResult GetFamilyByUserName(string userName)
        {
            return Ok(familyService.GetFamilyByUserName(userName));
        }

        [HttpGet]
        //[Route("ChekIfPasswordIsExist/{userName}/{password}")]
        [Route("ChekIfPasswordIsExist")]
        // GET: api/Family/5
        public IActionResult ChekIfPasswordIsExist(string userName, string password)
        {
            return Ok(familyService.ChekIfPasswordIsExist(userName, password));
        }

        [HttpPost("[action]")] 
        // POST: api/Family
        public IActionResult AddFamily([FromBody]UserDTO family)
        {
            familyService.AddFamilyToList(family);
            return Ok(familyService.GetAllFamilyList());
        }

        [HttpPut("[action]")] 
        // PUT: api/Family/5
        public IActionResult PutFamily([FromBody]UserDTO family)
        {
            familyService.PutFamily(family);
            return Ok(familyService.GetAllFamilyList());
        }

        [HttpDelete("[action]")]        // DELETE: api/Family/5
        public IActionResult DeleteFamily(string id)
        {
            familyService.DeleteFamily(id);
            return Ok(familyService.GetAllFamilyList());
        }
    }
}
