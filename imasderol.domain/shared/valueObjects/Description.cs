using imasderol.domain.shared.exceptions;

namespace imasderol.domain.shared.valueObjects;

public class Description
{
    public const int MaxLength = 500;
    
    public string Value { get; }

    internal Description(string value)
    {
        Validate(value);

        Value = value;
    }

    private static void Validate(string value)
    {
        if (value.Length > MaxLength)
        {
            throw new ValidationException($"The maximum length of the description is {MaxLength}");
        }
    }
}