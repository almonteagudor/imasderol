using imasderol.domain.shared.exceptions;
using imasderol.domain.zombicide.skill;

namespace imasderol.application.zombicide.skill.deleteSkillCommand;

public class DeleteSkillCommandHandler(ISkillRepository repository)
{
    /// <summary>
    /// Executes the deletion of a skill based on the provided DeleteSkillCommand.
    /// </summary>
    /// <param name="command">The DeleteSkillCommand containing the skill ID to delete.</param>
    /// <exception cref="NotDeletedException">Thrown when the skill cannot be deleted.</exception>
    /// <exception cref="NotFoundException">Thrown when a skill with the specified identifier is not found.</exception>
    public void Execute(DeleteSkillCommand command)
    {
        var skill = repository.FindById(Guid.Parse(command.Id));
        
        repository.Delete(skill);
    }
}