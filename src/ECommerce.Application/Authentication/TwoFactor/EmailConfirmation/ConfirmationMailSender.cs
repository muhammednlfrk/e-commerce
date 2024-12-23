using ECommerce.Domain.Exceptions;
using ECommerce.Domain.Helpers;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace ECommerce.Application.Authentication.TwoFactor.EmailConfirmation;

public sealed class ConfirmationMailSenderConfiguration
{
    public required string Host { get; set; }
    public int Port { get; set; }
    public bool EnableSSL { get; set; }
    public SmtpDeliveryMethod DeliveryMethod { get; set; }
    public required string From { get; set; }
    public required string Password { get; set; }
    public required string Subject { get; set; }
}

public class ConfirmationMailSender : IConfirmationMailSender
{
    private const string CONF_CODE_TAG = "%CONFCODE%";
    private const string FULL_NAME_TAG = "%FULL_NAME%";

    private readonly ConfirmationMailSenderConfiguration _config;
    private readonly string _htmlTemplate;

    public ConfirmationMailSender(ConfirmationMailSenderConfiguration config, string htmlTemplate)
    {
        ArgumentNullException.ThrowIfNull(config, nameof(config));
        ArgumentNullException.ThrowIfNullOrEmpty(htmlTemplate, nameof(htmlTemplate));

        _config = config;
        _htmlTemplate = htmlTemplate;
    }

    #region IConfirmationMailSender Implementation

    /// <inheritdoc/>
    public Task SendConfirmationMailAsync(string confirmationCode, User user)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(confirmationCode, nameof(confirmationCode));
        ArgumentNullException.ThrowIfNull(user, nameof(user));

        MailAddress from = new(address: _config.From);
        MailAddress to = new(address: user.Email.ConvertToUnsecureString());

        string htmlBody = createMailBody(
            confirmationCode: confirmationCode,
            userFullName: $"{user.FirstName} {user.LastName}");

        using MailMessage confirmationMail = new(from, to)
        {
            IsBodyHtml = true,
            Body = htmlBody,
            BodyEncoding = Encoding.Unicode,
            Subject = _config.Subject,
            SubjectEncoding = Encoding.Unicode,
            Priority = MailPriority.High
        };

        using SmtpClient smtpClient = new()
        {
            Host = _config.Host,
            Port = _config.Port,
            EnableSsl = _config.EnableSSL,
            DeliveryMethod = _config.DeliveryMethod,
            Credentials = new NetworkCredential(_config.From, _config.Password)
        };

        try
        {
            smtpClient.Send(confirmationMail);
            return Task.FromResult(true);
        }
        catch (Exception inner)
        {
            throw new EmailSendingException(inner.Message, inner);
        }
    }

    #endregion

    #region Private Methods

    private string createMailBody(string confirmationCode, string userFullName)
    {
        return _htmlTemplate
            .Replace(CONF_CODE_TAG, confirmationCode)
            .Replace(FULL_NAME_TAG, userFullName);
    }

    #endregion
}
