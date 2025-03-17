using Flow.Business.Helpers.DTOs.Contact;
using Flow.Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flow.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _services;

        public ContactController(IContactService services)
        {
            _services = services;
        }


        [HttpPost("send-email")]
        public async Task<IActionResult> SendEmail([FromBody] ContactFormDto contactForm)
        {
            if (contactForm == null) return BadRequest("Yalnis data");
            try
            {
                await _services.SendEmailAsync(contactForm);
                return Ok(new { message = "E-mail gonderildi" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "E-mail gonderilen vaxti xeta vas verdi", error = ex.Message });
            }
        }
    }

}
