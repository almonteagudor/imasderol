using imasderol.domain.shared.exceptions;
using imasderol.domain.zombicide.skill;

namespace imasderol.infrastructure.zombicide.skill;

public class SkillRepository(ImasderolDbContext context) : ISkillRepository
{
    public Skill FindById(string id)
    {
        var skill = context.Skills!.FirstOrDefault(skill => skill.Id == id);

        if (skill is null)
        {
            throw new NotFoundException($"Skill not found | {id}");
        }

        return skill;
    }

    public IEnumerable<Skill> GetAll()
    {
        return context.Skills!.ToList();
    }

    public void Save(Skill skill)
    {
        context.Skills!.Add(skill);
        context.SaveChanges();
    }

    public void Update(Skill updatedSkill)
    {
        var skill = context.Skills!.FirstOrDefault(skill => skill.Id == updatedSkill.Id);

        if (skill == null)
        {
            throw new NotFoundException($"Skill not found | {updatedSkill.Id}");
        }

        skill.Name = updatedSkill.Name;
        skill.Description = updatedSkill.Description;
        
        context.SaveChanges();
    }

    public void Delete(string id)
    {
        var skill = context.Skills!.FirstOrDefault(skill => skill.Id == id);

        if (skill == null)
        {
            throw new NotFoundException($"Skill not found | {id}");
        }
        
        context.Skills!.Remove(skill);
        
        context.SaveChanges();
    }
}