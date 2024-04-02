using MimeKit;
using MimeKit.Text;
using OptionsPattern.API.Extensions;
using OptionsPattern.API.Interfaces.Services;
using OptionsPattern.API.Interfaces.Settings;

namespace OptionsPattern.API.Services;

public sealed class EmailService(IEmailSender emailSender, IConfiguration configuration) : IEmailService
{
    public async Task<bool> SendEmailAsync(string email)
    {
        if (!email.IsValidEmail())
            return false;

        var mimeMessage = new MimeMessage()
        {
            Subject = "Random email sended!",
            Body = new TextPart(TextFormat.Text)
            {
                Text = "Random Email"
            },
            From = { MailboxAddress.Parse(configuration["EmailCredentials:From"]) }
        };

        await emailSender.SendEmailAsync(mimeMessage);

        return true;
    }
}
