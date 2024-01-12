using imasderol.domain.zombicide.skill;

namespace imasderol.application.zombicide.skill;

public class CreateUseCase(SkillCreator skillCreator)
{
    public Skill Execute(CreateRequest request)
    {
        return skillCreator.Execute(Guid.NewGuid(), request.Name, request.Description);
    }
}