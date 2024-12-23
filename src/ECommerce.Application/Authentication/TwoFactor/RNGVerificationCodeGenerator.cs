using System.Security.Cryptography;

namespace ECommerce.Application.Authentication.TwoFactor;

public class RNGVerificationCodeGenerator : IVerificationCodeGenerator
{
    /// <inheritdoc/>
    public Task<string> GenerateVerificationCodeForAsync()
    {
        byte[] randomBytes = new byte[4];
        using RandomNumberGenerator rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomBytes);
        int verificationCode = BitConverter.ToInt32(randomBytes, 0);
        verificationCode %= 1000000;
        verificationCode  = Math.Abs(verificationCode);
        string vcStr = verificationCode.ToString("D6");
        return Task.FromResult(vcStr);
    }
}
