using ECommerce.Domain.Helpers;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace ECommerce.Application.Authentication;

public class MD5PasswordHasher : IPasswordHasher
{
    private const int LOOP = 327;

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
            byte[] passwordHashBytes = MD5.HashData(passwordBytes);
            unsecurePassword = Convert.ToHexString(passwordHashBytes);
        }
        SecureString secureHashedPassword = unsecurePassword.ToReadOnlySecureString();
        return Task.FromResult(secureHashedPassword);
    }
}
