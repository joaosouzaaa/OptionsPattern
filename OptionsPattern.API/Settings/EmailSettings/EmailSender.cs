using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using OptionsPattern.API.Interfaces.Settings;
using OptionsPattern.API.Options;

namespace Support.Microservice.Settings.EmailSettings;

public sealed class EmailSender(IOptions<EmailCredentialsOptions> emailOptions) : IEmailSender
{
    private readonly EmailCredentialsOptions _emailCredentialsOptions = emailOptions.Value;

    public async Task SendEmailAsync(MimeMessage mailMessage)
    {
        using var smtpClient = new SmtpClient();

        await smtpClient.ConnectAsync(_emailCredentialsOptions.Host, _emailCredentialsOptions.Port, SecureSocketOptions.StartTls);
        await smtpClient.AuthenticateAsync(_emailCredentialsOptions.From, _emailCredentialsOptions.Password);

        await smtpClient.SendAsync(mailMessage);

        await smtpClient.DisconnectAsync(true);
    }
}
