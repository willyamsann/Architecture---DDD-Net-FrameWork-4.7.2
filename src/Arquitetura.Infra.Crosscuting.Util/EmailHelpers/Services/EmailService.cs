using Arquitetura.Infra.Crosscuting.Util.EmailHelpers.Interfaces;
using Arquitetura.Infra.Crosscuting.Util.EmailHelpers.Models;
using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Web;

namespace Arquitetura.Infra.Crosscuting.Util.EmailHelpers.Services
{
    public class EmailService : IEmailService
    {
        public Task SendAsync(EmailMessage message)
        {
            var msg = new MailMessage { From = new MailAddress("willyam.oliveira@mouradubeux.com.br", "atlas") };

            msg.To.Add(new MailAddress(message.Destination));
            msg.Subject = message.Subject;
            msg.IsBodyHtml = true;
            msg.Body = message.Body;

            var smtpClient = new SmtpClient(ConfigurationManager.AppSettings["Host"], Convert.ToInt32(ConfigurationManager.AppSettings["HostPort"]));
            var credentials = new NetworkCredential(ConfigurationManager.AppSettings["EmailAccount"],
                ConfigurationManager.AppSettings["EmailPassword"]);
            smtpClient.Credentials = credentials;
            smtpClient.EnableSsl = true;
            smtpClient.Send(msg);

            return Task.FromResult(0);
        }

        public void Dispose()
        {
        }
    }
}
