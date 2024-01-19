using imasderol.domain.zombicide.skill;

namespace imasderol.application.zombicide.skill.deleteSkillCommand;

public class DeleteSkillCommandHandler(ISkillRepository repository)
{
    public void Execute(DeleteSkillCommand command)
    {
        var skill = repository.FindById(Guid.Parse(command.Id));
        
        repository.Delete(skill);
    }
}