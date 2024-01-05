namespace imasderol.domain.shared.exceptions;

public class ValidationException : Exception
{
    public List<Exception> Exceptions { get; } = [];

    public void AddException(Exception exception)
    {
        Exceptions.Add(exception);
    }
    
    public void AddException(IEnumerable<Exception> exceptions)
    {
        Exceptions.AddRange(exceptions);
    }

    public bool HasExceptions()
    {
        return Exceptions.Count > 0;
    }
}