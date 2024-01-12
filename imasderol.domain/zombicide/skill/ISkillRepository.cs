namespace imasderol.domain.zombicide.skill;

public interface ISkillRepository
{
    public Skill FindById(Guid id);
    
    public IEnumerable<Skill> FindAll();
    
    public void Save(Skill skill);
    
    public void Update(Skill skill);
    
    public void Delete(Skill skill);
}