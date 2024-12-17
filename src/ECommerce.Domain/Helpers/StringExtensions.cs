using System.Runtime.InteropServices;
using System.Security;

namespace ECommerce.Domain.Helpers;

public static class StringExtensions
{
    /// <summary>
    /// Converts <see cref="string"/> to <see cref="SecureString"/>.
    /// </summary>
    /// <param name="str">
    /// The <see cref="string"/> value to gonna get converted to <see cref="SecureString"/>.
    /// <br/>
    /// <b>NOTE:</b> The value gonna be removed from memory.
    /// </param>
    /// <returns>
    /// The <paramref name="str"/> that converted <see cref="SecureString"/>.
    /// </returns>
    /// <exception cref="ArgumentNullException"/>
    public static SecureString ToReadOnlySecureString(this string str)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(str, nameof(str));
        SecureString result = new();
        foreach (char c in str)
            result.AppendChar(c);
        result.MakeReadOnly();
        GC.SuppressFinalize(str);
        return result;
    }

    /// <summary>
    /// Converts secure string to UTF-16.
    /// </summary>
    /// <param name="secureString">Secure string that gonna converted.</param>
    /// <returns>Returns UTF-16 value of the <paramref name="secureString"/></returns>
    public static string ConvertToUnsecureString(this SecureString secureString)
    {
        ArgumentNullException.ThrowIfNull(secureString, nameof(secureString));
        IntPtr unmanagedString = IntPtr.Zero;
        try
        {
            unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
            return Marshal.PtrToStringUni(unmanagedString) ?? "";
        }
        finally
        {
            Marshal.ZeroFreeCoTaskMemUnicode(unmanagedString);
        }
    }
}
