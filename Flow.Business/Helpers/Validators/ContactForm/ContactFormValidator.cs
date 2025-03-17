using Flow.Business.Helpers.DTOs.Contact;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flow.Business.Helpers.Validators.ContactForm
{
    public class ContactFormValidator : AbstractValidator<ContactFormDto>
    {
        public ContactFormValidator()
        {
            RuleFor(x=>x.FullName).NotEmpty().WithMessage("Ad və soyad mütləq daxil edilməlidir.");
            RuleFor(x => x.Email).EmailAddress().NotEmpty().WithMessage("Email mütləq daxil edilməlidir.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Basliq mütləq daxil edilməlidir.");
            RuleFor(x => x.Comment).NotEmpty().WithMessage("Mesaj mütləq daxil edilməlidir.");
        }
    }
}
