using imasderol.domain.zombicide.skill;

namespace imasderol.application.zombicide.skill.createSkillCommand;

public class CreateSkillCommandHandler(SkillCreator skillCreator, ISkillRepository repository)
{
    public Skill Execute(CreateSkillCommand skillCommand)
    {
        var skill = skillCreator.Execute(Guid.NewGuid(), skillCommand.Name, skillCommand.Description);
        
        repository.Save(skill);

        return skill;
    }
}