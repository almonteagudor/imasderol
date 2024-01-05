using imasderol.domain.shared.exceptions;

namespace imasderol.domain.zombicide.skill;

public class SkillFinder(ISkillRepository repository)
{
    /// <exception cref="NotFoundException"></exception>
    public Skill Execute(Guid id)
    {
        return repository.FindById(id);
    }
}