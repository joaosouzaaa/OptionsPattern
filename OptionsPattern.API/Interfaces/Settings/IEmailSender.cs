using MimeKit;

namespace OptionsPattern.API.Interfaces.Settings;

public interface IEmailSender
{
    Task SendEmailAsync(MimeMessage mailMessage);
}
