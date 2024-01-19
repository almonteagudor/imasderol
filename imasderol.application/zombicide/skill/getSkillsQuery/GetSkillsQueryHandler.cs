using imasderol.domain.zombicide.skill;

namespace imasderol.application.zombicide.skill.getSkillsQuery;

public class GetSkillsQueryHandler(ISkillRepository repository)
{
    /// <summary>
    /// Gets all skills.
    /// </summary>
    /// <returns>An IEnumerable of skills.</returns>
    public IEnumerable<Skill> Execute()
    {
        return repository.GetAll();
    }
}