using Microsoft.Extensions.Configuration;
using MimeKit;
using Moq;
using OptionsPattern.API.Interfaces.Settings;
using OptionsPattern.API.Services;

namespace UnitTests.ServiceTests;
public sealed class EmailServiceTests
{
    private readonly Mock<IEmailSender> _emailSenderMock;
    private readonly IConfiguration _configuration;
    private readonly EmailService _emailService;

    public EmailServiceTests()
    {
        _emailSenderMock = new Mock<IEmailSender>();
        var inMemoryCollection = new Dictionary<string, string>()
        {
            {"EmailCredentials:From", "test" }
        };
        _configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemoryCollection!)
            .Build();
        _emailService = new EmailService(_emailSenderMock.Object, _configuration);
    }

    [Fact]
    public async Task SendEmailAsync_SuccessfulScenario_ReturnsTrue()
    {
        // A
        var validEmail = "valid@test.com";

        _emailSenderMock.Setup(e => e.SendEmailAsync(It.IsAny<MimeMessage>()));

        // A
        var sendEmailResult = await _emailService.SendEmailAsync(validEmail);

        // A
        _emailSenderMock.Verify(e => e.SendEmailAsync(It.IsAny<MimeMessage>()), Times.Once());

        Assert.True(sendEmailResult);
    }

    [Fact]
    public async Task SendEmailAsync_InvalidEmail_ReturnsFalse()
    {
        // A
        var invalidEmail = "valid@";

        // A
        var sendEmailResult = await _emailService.SendEmailAsync(invalidEmail);

        // A
        _emailSenderMock.Verify(e => e.SendEmailAsync(It.IsAny<MimeMessage>()), Times.Never());

        Assert.False(sendEmailResult);
    }
}
