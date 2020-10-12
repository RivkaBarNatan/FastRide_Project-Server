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
    public class SchedulesController : ControllerBase
    {
        private readonly SchedulesService schedulesService;

        public SchedulesController(SchedulesService schedulesService)
        {
            this.schedulesService = schedulesService;
        }

        // GET: api/<SchedulerController>
        [HttpGet("[action]")]
        public IActionResult GetAllSchedulersList()
        {
            return Ok(schedulesService.GetAllSchedulesList());
        }

        // GET api/<SchedulerController>/5
        [HttpGet("[action]")]
        public IActionResult GetSchedulerById(string id)
        {
            return Ok(schedulesService.GetScheduleById(id));
        }

        // POST api/<SchedulerController>
        [HttpPost("[action]")]
        public IActionResult AddScheduler([FromBody] SchedulesDTO schedule)
        {
            schedulesService.AddScheduleToList(schedule);
            return Ok(GetAllSchedulersList());
        }

        // PUT api/<SchedulerController>/5
        [HttpPut("[action]")]
        public IActionResult Put([FromBody] SchedulesDTO schedule)
        {
            schedulesService.PutSchedule(schedule);
            return Ok(GetAllSchedulersList());
        }

        // DELETE api/<SchedulerController>/5
        [HttpDelete("[action]")]
        public IActionResult DeleteScheduler(string id)
        {
            schedulesService.DeleteSchedule(id);
            return Ok(GetAllSchedulersList());
        }
    }
}
