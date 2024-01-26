using imasderol.domain.shared.exceptions;
using imasderol.domain.zombicide.skill;

namespace imasderol.application.zombicide.skill.findSkillByIdQuery;

public class FindSkillByIdQueryHandler(ISkillRepository repository)
{
    /// <summary>
    /// Executes the retrieval of a skill based on the provided FindSkillByIdQuery.
    /// </summary>
    /// <param name="query">The FindSkillByIdQuery containing the skill ID to retrieve.</param>
    /// <returns>The skill with the specified identifier, or throws a <see cref="NotFoundException"/> if not found.</returns>
    /// <exception cref="NotFoundException">Thrown when a skill with the specified identifier is not found.</exception>
    public Skill Execute(FindSkillByIdQuery query)
    {
        return repository.FindById(query.Id);
    }
}