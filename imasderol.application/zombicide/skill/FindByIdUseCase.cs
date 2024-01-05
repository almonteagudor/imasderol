using imasderol.domain.zombicide.skill;
using imasderol.domain.shared.exceptions;

namespace imasderol.application.zombicide.skill;

public class FindByIdUseCase(SkillFinder skillFinder)
{
    /// <exception cref="NotFoundException"></exception>
    public Skill Execute(Guid id)
    {
        return skillFinder.Execute(id);
    }
}