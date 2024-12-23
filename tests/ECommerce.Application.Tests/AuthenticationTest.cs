using ECommerce.Application.Authentication;
using ECommerce.Application.Authentication.TwoFactor;
using ECommerce.Domain.Helpers;
using System.Security;

namespace ECommerce.Application.Tests;

public class AuthenticationTest
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

    [Fact]
    public async Task PasswordHasherTest()
    {
        PasswordHasher passwordHasher = new(config: new PasswordHasherConfiguration
        {
            AlgorithmName = PasswordHashingAlgorithmName.SHA256
        });
        SecureString passwordGonnaHash = "!1Mn%&ü 8pLC".ToReadOnlySecureString();

        SecureString sHashedPassword = await passwordHasher.HashPasswordAsync(passwordGonnaHash);
        string hashedPassword = sHashedPassword.ConvertToUnsecureString();

        Assert.Equal(
            expected: "b727c8fc7774fc66d75d96e407dae8067cc2d3063bf956e9f725aa0d06dcb4d6",
            actual: hashedPassword);
    }
}