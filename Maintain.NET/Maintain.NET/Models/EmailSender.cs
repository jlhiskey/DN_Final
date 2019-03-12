using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Maintain.NET.Models
{
    public class EmailSender : IEmailSender
    {
        private IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Send an email to the user
        /// </summary>
        /// <param name="email"></param>
        /// <param name="subject"></param>
        /// <param name="htmlMessage"></param>
        /// <returns></returns>
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            
            string key = _configuration["Sendgrid_Api_Key"];
            SendGridClient client = new SendGridClient(key);

            SendGridMessage msg = new SendGridMessage();

            var from = new EmailAddress("noreply@MaintainNET.com", "Maintain.NET Admin");
            var to = new EmailAddress(email);

            var message = MailHelper.CreateSingleEmail(from, to, subject, "something is wrong", "hey");

            msg.SetFrom("noreply.Maintain.NET.com", "Maintain.NET Admin");

            msg.AddTo(email);
            msg.SetSubject(subject);
            msg.AddContent(MimeType.Text, htmlMessage);

            var result = await client.SendEmailAsync(message);
        }
    }
}
