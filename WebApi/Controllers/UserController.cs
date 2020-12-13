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
        private readonly UserService UserService;
        public UserController(UserService UserService)
        {
            this.UserService = UserService;
        }
        [HttpGet("[action]")]   
        // GET: api/User
        public IActionResult GetAllUserList()
        {
            return Ok(UserService.GetAllUsersList());
        }

        [HttpGet("[action]")]
        // GET: api/User/5
        public IActionResult GetUserByUserId(string userId)
        {
            return Ok(UserService.GetUserByUserId(userId));
        }

        [HttpGet]
        //[Route("ChekIfPasswordIsExist/{userName}/{password}")]
        [Route("ChekIfPasswordIsExist")]
        // GET: api/User/5
        public IActionResult ChekIfPasswordIsExist(string userName, string password)
        {
            return Ok(UserService.ChekIfPasswordIsExist(userName, password));
        }

        [HttpPost("[action]")] 
        // POST: api/User
        public IActionResult AddUser([FromBody]UserDTO User)
        {
            UserService.AddUserToList(User);
            return Ok(UserService.GetAllUsersList());
        }

        [HttpPut("[action]")] 
        // PUT: api/User/5
        public IActionResult PutUser([FromBody]UserDTO User)
        {
            UserService.PutUser(User);
            return Ok(UserService.GetAllUsersList());
        }

        [HttpDelete("[action]")]        // DELETE: api/User/5
        public IActionResult DeleteUser(string id)
        {
            UserService.DeleteUser(id);
            return Ok(UserService.GetAllUsersList());
        }
    }
}
