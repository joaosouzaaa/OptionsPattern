namespace OptionsPattern.API.Interfaces.Services;

public interface IEmailService
{
    Task<bool> SendEmailAsync(string email);
}
