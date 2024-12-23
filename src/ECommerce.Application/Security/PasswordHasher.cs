using ECommerce.Domain.Helpers;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace ECommerce.Application.Security;

public class PasswordHasher : IPasswordHasher
{
    private const int LOOP = 327;

    private readonly PasswordHasherConfiguration _config;

    public PasswordHasher(PasswordHasherConfiguration? config)
    {
        config ??= new PasswordHasherConfiguration { AlgorithmName = "SHA256" };
        ArgumentException.ThrowIfNullOrEmpty(config.AlgorithmName, nameof(config.AlgorithmName));
        _config = config;
    }

    #region IPasswordHasher Implementation

    /// <inheritdoc/>
    public Task<SecureString> HashPasswordAsync(SecureString password)
    {
        /** VERY IMPORTANT!
         * DO NOT CHANGE THIS ALGORITHM. EVEN IF RUNS SLOW. THIS RUNS SOME
         * SERIOUS SHIT.
         */
        string unsecurePassword = password.ConvertToUnsecureString();
        char head = unsecurePassword[0];
        char tail = unsecurePassword[^1];
        for (int i = 0; i < LOOP; i++)
        {
            if (i % 2 == 0)
                unsecurePassword = tail + unsecurePassword + head + tail;
            byte[] passwordBytes = Encoding.Unicode.GetBytes(unsecurePassword);
            byte[] passwordHashBytes = hash(passwordBytes);
            unsecurePassword = BitConverter.ToString(passwordHashBytes)
                .Replace("-", "")
                .ToLower();
        }
        SecureString secureHashedPassword = unsecurePassword.ToReadOnlySecureString();
        return Task.FromResult(secureHashedPassword);
    }

    #endregion

    #region Private Methods

    private byte[] hash(byte[] inputBytes)
    {
        return _config.AlgorithmName switch
        {
            "SHA256" => SHA256.HashData(inputBytes),
            "SHA384" => SHA384.HashData(inputBytes),
            "SHA512" => SHA512.HashData(inputBytes),
            "SHA1" => SHA1.HashData(inputBytes),
            "MD5" => MD5.HashData(inputBytes),
            _ => throw new ArgumentException($"Unsupported algorithm {_config.AlgorithmName}"),
        };
    }

    #endregion

    #region Types

    /// <summary>
    /// Configuration for <see cref="PasswordHasher"/>.
    /// </summary>
    public sealed class PasswordHasherConfiguration
    {
        /// <summary>
        /// The hasing algorithm name for hashing.
        /// </summary>
        public required string AlgorithmName { get; init; }
    }

    #endregion
}
