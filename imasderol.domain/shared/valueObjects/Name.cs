using imasderol.domain.shared.exceptions;

namespace imasderol.domain.shared.valueObjects;

public class Name
{
    public string Value { get; init; }

    private const int MinLength = 3;
    private const int MaxLength = 100;

    public Name(string value)
    {
        Validate(value);

        Value = value;
    }

    private static void Validate(string value)
    {
        var validationException = new ValidationException();

        switch (value.Length)
        {
            case < MinLength:
                validationException.AddException(
                    new MinLengthException($"The minimum length of the name is {MinLength}")
                );
                break;
            case > MaxLength:
                validationException.AddException(
                    new MaxLengthException($"The maximum length of the name is {MaxLength}")
                );
                break;
        }

        if (validationException.HasExceptions())
        {
            throw validationException;
        }
    }
}