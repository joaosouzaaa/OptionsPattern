using Microsoft.AspNetCore.Mvc;
using OptionsPattern.API.Interfaces.Services;

namespace OptionsPattern.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public sealed class EmailController(IEmailService emailService) : ControllerBase
{
    [HttpPost("send-email")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public Task<bool> SendEmailAsync([FromQuery] string email) =>
        emailService.SendEmailAsync(email);
}
