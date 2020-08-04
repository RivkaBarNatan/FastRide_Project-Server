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
    public class FrequencyController : ControllerBase
    {
        private readonly FrequencyService frequencyService;
        public FrequencyController(FrequencyService frequencyService)
        {
            this.frequencyService = frequencyService;
        }
        [HttpGet("[action]")]        // GET: api/Frequency
        public IActionResult GetAllFrequencyList()
        {
            return Ok(frequencyService.GetAllFrequencyList());
        }

        [HttpGet("[action]")]        // GET: api/Frequency/5
        public IActionResult GetFrequencyByType(string type)
        {
            return Ok(frequencyService.GetFrequencyByType(type));
        }

        [HttpPost("[action]")]        // POST: api/Frequency
        public IActionResult AddFrequency([FromBody]FrequencyDTO frequency)
        {
            frequencyService.AddFrequencyToList(frequency);
            return Ok(frequencyService.GetAllFrequencyList());
        }

        [HttpPut("[action]")]        // PUT: api/Frequency/5
        public IActionResult PutFrequency([FromBody]FrequencyDTO frequency)
        {
            frequencyService.PutFrequency(frequency);
            return Ok(frequencyService.GetAllFrequencyList());
        }

        [HttpDelete("[action]")]        // DELETE: api/Frequency/5
        public IActionResult DeleteFrequency(string id)
        {
            frequencyService.DeleteFrequency(id);
            return Ok(frequencyService.GetAllFrequencyList());
        }
    }
}
