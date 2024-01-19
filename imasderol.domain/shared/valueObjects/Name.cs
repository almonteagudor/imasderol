using imasderol.domain.shared.exceptions;

namespace imasderol.domain.shared.valueObjects;

public class Name
{
    public const int MinLength = 3;
    public const int MaxLength = 100;

    public string Value { get; }

    internal Name(string value)
    {
        Validate(value);

        Value = value;
    }

    private static void Validate(string value)
    {
        switch (value.Length)
        {
            case < MinLength:
                throw new ValidationException($"The minimum length of the name is {MinLength}");
            case > MaxLength:
                throw new ValidationException($"The maximum length of the name is {MaxLength}");
        }
    }
}