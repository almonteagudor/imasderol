using imasderol.domain.shared.exceptions;
using imasderol.domain.shared.valueObjects;

namespace imasderol.domain.zombicide.skill;

public class SkillCreator
{
    /// <summary>
    /// Executes an operation that creates an instance of the Skill class based on the provided data.
    /// </summary>
    /// <param name="id">The unique identifier for the Skill.</param>
    /// <param name="name">The name of the Skill.</param>
    /// <param name="description">The description of the Skill.</param>
    /// <returns>An instance of Skill created with the provided data.</returns>
    /// <exception cref="ValidationException">Thrown if there are validation errors in the name or description parameters.</exception>
    public Skill Execute(Guid id, string name, string description)
    {
        var failedValidations = new ValidationException();

        var skillName = ValidateAndCreate(() => new Name(name), failedValidations);
        var skillDescription = ValidateAndCreate(() => new Description(description), failedValidations);

        if (failedValidations.HasMessages()) throw failedValidations;
        
        return new Skill(id, skillName, skillDescription);
    }
    
    private T ValidateAndCreate<T>(Func<T> createFunction, ValidationException failedValidations)
    {
        try
        {
            return createFunction();
        }
        catch (ValidationException e)
        {
            failedValidations.AddMessages(e.Messages);
            
            return default!;
        }
    }
}