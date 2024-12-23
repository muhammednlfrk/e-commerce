using ECommerce.Application.Security;
using ECommerce.Domain.Helpers;
using System.Security;

namespace ECommerce.Application.Tests;

public class SecurityTests
{
    [Fact]
    public async Task PasswordHasherTest()
    {
        PasswordHasher passwordHasher = new(config: new PasswordHasher.PasswordHasherConfiguration
        {
            AlgorithmName = HashingAlgorithm.SHA256
        });
        SecureString passwordGonnaHash = "!1Mn%&ü 8pLC".ToReadOnlySecureString();

        SecureString sHashedPassword = await passwordHasher.HashPasswordAsync(passwordGonnaHash);
        string hashedPassword = sHashedPassword.ConvertToUnsecureString();

        Assert.Equal(
            expected: "b727c8fc7774fc66d75d96e407dae8067cc2d3063bf956e9f725aa0d06dcb4d6",
            actual: hashedPassword);
    }
}
