using imasderol.domain.shared.exceptions;
using imasderol.domain.zombicide.skill;
using Microsoft.EntityFrameworkCore;

namespace imasderol.infrastructure.zombicide.skill;

public class SkillRepository(ImasderolDbContext context) : ISkillRepository
{
    public Skill FindById(Guid id)
    {
        var skill = context.Skills!.FirstOrDefault(s => s.Id == id);

        if (skill is null)
        {
            throw new NotFoundException($"Skill not found | {id}");
        }

        return skill;
    }

    public IEnumerable<Skill> FindAll()
    {
        return context.Skills!.ToList();
    }

    public void Save(Skill skill)
    {
        context.Skills!.Add(skill);
        context.SaveChanges();
    }

    public void Update(Skill skill)
    {
        context.Entry(skill).State = EntityState.Modified;
        context.SaveChanges();
    }

    public void Delete(Skill skill)
    {
        context.Entry(skill).State = EntityState.Deleted;
        context.SaveChanges();
    }
}