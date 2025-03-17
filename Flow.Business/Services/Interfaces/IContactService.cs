using Flow.Business.Helpers.DTOs.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flow.Business.Services.Interfaces
{
    public interface IContactService
    {
        Task SendEmailAsync(ContactFormDto contactForm);
    }
}
