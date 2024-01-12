using imasderol.domain.shared.exceptions;
using imasderol.domain.shared.valueObjects;

namespace imasderol.domain.zombicide.skill;

public class SkillCreator(ISkillRepository repository)
{
    public Skill Execute(Guid id, string name, string description)
    {
        var validationException = new ValidationException();
        
        Name skillName = null!;
        
        try
        {
            skillName = new Name(name);
        }
        catch (ValidationException e)
        {
            validationException.AddException(e.Exceptions);
        }
        
        Description skillDescription = null!;
        
        try
        {
            skillDescription = new Description(description);
        }
        catch (ValidationException e)
        {
            validationException.AddException(e.Exceptions);
        }

        if (validationException.HasExceptions()) throw validationException;
        
        var skill = new Skill(id, skillName, skillDescription);
        
        repository.Save(skill);

        return skill;
    }
}