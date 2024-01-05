using imasderol.domain.zombicide.skill;
using imasderol.domain.shared.exceptions;

namespace imasderol.application.zombicide.skill;

public class CreateUseCase(SkillCreator skillCreator)
{
    /// <exception cref="ValidationException"></exception>
    /// <exception cref="NotSavedException"></exception>
    public Skill Execute(string name, string description)
    {
        return skillCreator.Execute(Guid.NewGuid(), name, description);
    }
}