using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Email
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly EmailSender _emailSender;
        public EmailController(EmailSender emailSender)
        {
            _emailSender = emailSender;
        }
        // GET: api/<EmailController>
        [HttpGet]
        public IActionResult Get()
        {
            var message = new Message(new string[] { "rivkib211@gmail.com", "kleind96126@gmail.com" }, "בדיקת שליחת מייל מהאתר", "אם קיבלת את המייל הזה, זה עובד!! צריך רק ליצור אימייל לאתר שלנו ולשלוח ממנו! אני רק לא יודעת למה הוא לא כותב את הנושא. אני עושה קומיט ופוש כדי שתוכלי לחזות במו עינייך... ואם תרצי, אפשר לעשות זה גם דף HTML הקישור ממנו עשיתי הכל וגם הדפים היפים שם,: https://code-maze.com/send-email-with-attachments-aspnetcore-2/!");
            _emailSender.SendEmail(message);
            return Ok();
        }

        // GET api/<EmailController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmailController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EmailController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmailController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
