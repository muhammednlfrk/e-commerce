namespace ECommerce.Domain.Exceptions;

[Serializable]
public class EmailSendingException : Exception
{
    const string DEFAULT_MESSAGE = "An exception occured when the mail sending";

    public EmailSendingException(string message = DEFAULT_MESSAGE) : base(message) { }
    public EmailSendingException(string message, Exception inner) : base(message, inner) { }
    public EmailSendingException(Exception inner) : base(DEFAULT_MESSAGE, inner) { }
}
