using ECommerce.Application.Authentication.TwoFactor;

namespace ECommerce.Application.Tests;

public class AuthenticationTests
{
    [Fact]
    public async Task RNGVerificationCodeGenerationTest()
    {
        IVerificationCodeGenerator verificationCodeGenerator = new RNGVerificationCodeGenerator();
        string verificationCode = await verificationCodeGenerator.GenerateVerificationCodeForAsync();

        Assert.True(
            condition: (verificationCode.Length == 6 && !verificationCode.Any(c => !char.IsNumber(c))),
            userMessage: $"Invalid validation code generated. Generated code: \"{verificationCode}\"");
    }
}