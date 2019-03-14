using Maintain.NET.Models.Interfaces;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;


namespace Maintain.NET.Models
{
    public class EmailSender : IEmailSender
    {
        private IConfiguration _configuration;

        private readonly IUserTaskManager _usertask;

        private long sendAt { get; set; }

        public EmailSender(IConfiguration configuration, IUserTaskManager usertask)
        {
            _configuration = configuration;

            _usertask = usertask;
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
            SendGridClient client = new SendGridClient(_configuration["Sendgrid_Api_Key"]);

            SendGridMessage msg = new SendGridMessage();

            msg.SetFrom("noreply@Maintain.NET.com", "Maintain.NET Admin");

            msg.AddTo(email);

            msg.SetSubject(subject);

            msg.AddContent(MimeType.Text, htmlMessage);

            if(sendAt > 0)
            {
                msg.SendAt = sendAt;

                await client.SendEmailAsync(msg);
            }
            

            var result = await client.SendEmailAsync(msg);
        }

        public async Task GetDate(long date)
        {
            sendAt = date;
        }
    }
}
