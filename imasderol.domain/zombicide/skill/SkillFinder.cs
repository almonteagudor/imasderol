namespace imasderol.domain.zombicide.skill;

public class SkillFinder(ISkillRepository repository)
{
    public Skill Execute(Guid id)
    {
        return repository.FindById(id);
    }
}