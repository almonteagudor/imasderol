using imasderol.domain.zombicide.skill;

namespace imasderol.application.zombicide.skill.findSkillByIdQuery;

public class FindSkillByIdQueryHandler(ISkillRepository repository)
{
    public Skill Execute(FindSkillByIdQuery query)
    {
        return repository.FindById(Guid.Parse(query.Id));
    }
}