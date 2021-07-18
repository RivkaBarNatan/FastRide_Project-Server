using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using DAL;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Microsoft.Extensions.Hosting;

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

        [HttpGet]
        [Route("sendEmailCommit")]
        public IActionResult SendEmailCommit([FromQuery]List<string> email, string subjectMail, string bodyMail)
        {
            try
            {
                var fromAddress = new MailAddress("optimal.fastride@gmail.com", "Fast Ride");
                var toAddress = new MailAddressCollection();
                foreach (var item in email)
                {
                    toAddress.Add(item);
                }
                const string fromPassword = "optimalitupyhnh";
                string subject = subjectMail;

                //string body = string.Empty;
                //using (StreamReader reader = new StreamReader(IHostingEnvironment.WebRootPath, "~/createTransportation.html"))
                //{
                //    body = reader.ReadToEnd();
                //}

                string body = @bodyMail;
                //string body = bodyMail;

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                using (var message = new MailMessage()
                {
                    From = fromAddress,
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                })
                {
                    message.To.Add(toAddress.ToString());
                    smtp.Send(message);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound( ex.Message);
            }
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
