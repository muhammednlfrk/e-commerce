using ECommerce.Domain.Exceptions;

namespace ECommerce.Application.Authentication.TwoFactor.EmailConfirmation;

/// <summary>
/// Includes functionalities to send confirmation mail to the user.
/// </summary>
public interface IConfirmationMailSender
{
    /// <summary>
    /// Sends a confirmation mail to the user.
    /// </summary>
    /// <param name="confirmationCode">The confirmation code gonna sended.</param>
    /// <param name="user">The user gonna recieve the condfirmation mail.</param>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="EmailSendingException"/>
    Task SendConfirmationMailAsync(string confirmationCode, User user);
}
