using System.Net.Mail;

namespace OptionsPattern.API.Extensions;

public static class EmailValidator
{
    public static bool IsValidEmail(this string email)
    {
        try
        {
            var mailAddress = new MailAddress(email);

            return true;
        }
        catch
        {
            return false;
        }
    }
}
