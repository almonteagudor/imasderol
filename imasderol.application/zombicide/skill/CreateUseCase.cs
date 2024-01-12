using imasderol.domain.zombicide.skill;

namespace imasderol.application.zombicide.skill;

public class CreateUseCase(SkillCreator skillCreator)
{
    public Skill Execute(string name, string description)
    {
        return skillCreator.Execute(Guid.NewGuid(), name, description);
    }
}