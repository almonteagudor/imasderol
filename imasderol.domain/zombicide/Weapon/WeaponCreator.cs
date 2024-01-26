using imasderol.domain.shared.exceptions;
using imasderol.domain.shared.valueObjects;
using imasderol.domain.zombicide.Weapon.ValueObjects;
using static imasderol.domain.zombicide.Weapon.ValueObjects.Type;

namespace imasderol.domain.zombicide.weapon;

public class WeaponCreator
{
    /// <summary>
    /// Executes an operation that creates an instance of the Skill class based on the provided data.
    /// </summary>
    /// <param name="id">The unique identifier for the Skill.</param>
    /// <param name="name">The name of the Skill.</param>
    /// <param name="description">The description of the Skill.</param>
    /// <returns>An instance of Skill created with the provided data.</returns>
    /// <exception cref="ValidationException">Thrown if there are validation errors in the name or description parameters.</exception>
    public Weapon Execute(Guid id, string name, bool dualwield, bool opensDoors, bool opensDoorsSilently, )
    {
        var failedValidations = new ValidationException();

        var weaponName = ValidateAndCreate(() => new Name(name), failedValidations);
        var canOpenDoors = ValidateAndCreate(() => new OpensDoors(opensDoors,opensDoorsSilently), failedValidations);

        var primaryAttack = ValidateAndCreate(() => new Attack(Guid.NewGuid(),Type( ), failedValidations);
        if (failedValidations.HasMessages()) throw failedValidations;

        return null; //new Weapon(id, weaponName, dualwield, canOpenDoors, );
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