using OptionsPattern.API.Extensions;

namespace UnitTests.ExtensionsTests;
public sealed class EmailValidatorTests
{
    [Fact]
    public void IsValidEmail_SuccessfulScenario_ReturnsTrue()
    {
        // A
        var validEmail = "test@valid.com";

        // A
        var isValidEmail = validEmail.IsValidEmail();

        // A
        Assert.True(isValidEmail);
    }

    [Theory]
    [MemberData(nameof(InvalidEmailParameters))]
    public void IsValidEmail_InvalidEmail_ReturnsFalse(string invalidEmail)
    {
        var isValidEmail = invalidEmail.IsValidEmail();

        Assert.False(isValidEmail);
    }

    public static TheoryData<string> InvalidEmailParameters() =>
        new()
        {
            "",
            "test",
            "@@@",
            "@invalid.com",
            "test.com@"
        };
}
