namespace ECommerce.Application.Authentication.TwoFactor;

/// <summary>
/// Defines functionalities for generating verification codes for <see cref="User"/>.
/// </summary>
public interface IVerificationCodeGenerator
{
    /// <summary>
    /// Generates verification code.
    /// </summary>
    /// <returns>Returns randomly generated 6-digit code.</returns>
    Task<string> GenerateVerificationCodeForAsync();
}
