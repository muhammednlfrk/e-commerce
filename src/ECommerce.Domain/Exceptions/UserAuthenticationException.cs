namespace ECommerce.Domain.Exceptions;

[Serializable]
public class UserAuthenticationException(string message) : Exception(message)
{
    public static UserAuthenticationException Throw(string message) => throw new UserAuthenticationException(message);
}
