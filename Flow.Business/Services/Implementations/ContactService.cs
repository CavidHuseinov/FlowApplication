using Flow.Business.Helpers.DTOs.Contact;
using Flow.Business.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Flow.Business.Services.Implementations
{
    public class ContactService : IContactService
    {
        private readonly IConfiguration _config;

        public ContactService(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendEmailAsync(ContactFormDto contactForm)
        {
            using var smtpClient = new SmtpClient(_config["Email:SmtpServer"])
            {
                Port = int.Parse(_config["Email:Port"]),
                Credentials = new NetworkCredential(_config["Email:Username"], _config["Email:Password"]),
                EnableSsl = true,
            };

            using var mailMessage = new MailMessage
            {
                From = new MailAddress(_config["Email:From"], contactForm.FullName),
                Subject = contactForm.Subject,
                Body = contactForm.Comment,
                IsBodyHtml = true,
            };

            mailMessage.To.Add(contactForm.Email);

            await smtpClient.SendMailAsync(mailMessage);
        }

    }
}
