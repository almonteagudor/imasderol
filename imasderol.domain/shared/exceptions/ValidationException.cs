namespace imasderol.domain.shared.exceptions;

public class ValidationException : Exception
{
    public List<string> Messages { get; }

    public ValidationException()
    {
        Messages = [];
    }

    public ValidationException(string message)
    {
        Messages = [message];
    }

    public ValidationException(IEnumerable<string> messages)
    {
        Messages = messages.ToList();
    }

    public void AddMessages(string message)
    {
        Messages.Add(message);
    }

    public void AddMessages(IEnumerable<string> messages)
    {
        Messages.AddRange(messages);
    }

    public bool HasMessages()
    {
        return Messages.Count > 0;
    }
}