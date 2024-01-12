using imasderol.domain.shared.exceptions;

namespace imasderol.domain.shared.valueObjects;

public class Description
{
    public string Value { get; init; }

    private const int MaxLength = 500;

    public Description(string value)
    {
        Validate(value);

        Value = value;
    }

    private static void Validate(string value)
    {
        var validationException = new ValidationException();

        if (value.Length <= MaxLength) return;

        validationException.AddException(
            new MaxLengthException($"The maximum length of the description is {MaxLength}")
        );

        throw validationException;
    }
}