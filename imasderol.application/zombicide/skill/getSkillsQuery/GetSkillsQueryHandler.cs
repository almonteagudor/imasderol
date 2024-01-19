using imasderol.domain.zombicide.skill;

namespace imasderol.application.zombicide.skill.getSkillsQuery;

public class GetSkillsQueryHandler(ISkillRepository repository)
{
    public IEnumerable<Skill> Execute()
    {
        return repository.GetAll();
    }
}