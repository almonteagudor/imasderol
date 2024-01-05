using imasderol.domain.shared.exceptions;

namespace imasderol.domain.zombicide.skill;

public interface ISkillRepository
{
    /// <exception cref="NotFoundException"></exception>
    public Skill FindById(Guid id);
    
    public IEnumerable<Skill> FindAll();
    
    /// <exception cref="NotSavedException"></exception>
    public void Save(Skill skill);
    
    /// <exception cref="NotUpdatedException"></exception>
    public void Update(Skill skill);
    
    /// <exception cref="NotDeletedException"></exception>
    public void Delete(Skill skill);
}