using System;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraController.Services
{
    public class Notifications
    {
        public Boolean SendEmail(string subject, string content, string toName, string toEmail)
        {
            var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("angie.1701812633@ucaldas.edu.co", "Angie Camelo Ortiz");
            var to = new EmailAddress(toEmail, toName);
            var plainTextContent = content;
            var htmlContent = content;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = client.SendEmailAsync(msg);
            return true;
        }

        public Boolean SendSMS(string content, string to, string from)
        {
            //twillio service
            return true;
        }
    }
}
