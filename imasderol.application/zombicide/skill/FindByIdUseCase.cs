using imasderol.domain.zombicide.skill;

namespace imasderol.application.zombicide.skill;

public class FindByIdUseCase(SkillFinder skillFinder)
{
    public Skill Execute(Guid id)
    {
        return skillFinder.Execute(id);
    }
}