using DirectMail.Models;
using System.Net.Mail;
using System.Threading.Tasks;

namespace DirectMail.Helpers
{
    public class EmailHelper
    {
        private readonly SmtpClient smtpClient;
        private readonly string mainMail;

        public EmailHelper(SmtpClient smtpClient, string mainMail)
        {
            this.smtpClient = smtpClient;
            this.mainMail = mainMail;
        }

        public async Task SendMail(Message model)
        {
            using (var message = new MailMessage(mainMail, mainMail)
            {
                Subject = model.Subject,
                Body = $"Nome: {model.FirstName} {model.LastName}\r\nE-mail: {model.Email}\r\n\r\n{model.Description}"
            })
            {
                await smtpClient.SendMailAsync(message);
            }
        }
    }
    }
