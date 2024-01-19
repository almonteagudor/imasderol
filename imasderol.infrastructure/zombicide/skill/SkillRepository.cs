using imasderol.domain.shared.exceptions;
using imasderol.domain.zombicide.skill;

namespace imasderol.infrastructure.zombicide.skill;

public class SkillRepository(ImasderolDbContext context, SkillCreator skillCreator) : ISkillRepository
{
    public Skill FindById(Guid id)
    {
        var skill = context.Skills!.FirstOrDefault(s => s.Id == id);

        if (skill is null)
        {
            throw new NotFoundException($"Skill not found | {id}");
        }

        return DtoToSkill(skill);
    }

    public IEnumerable<Skill> GetAll()
    {
        var skills = context.Skills!.ToList();

        return skills.Select(DtoToSkill);
    }

    public void Save(Skill skill)
    {
        context.Skills!.Add(SkillToDto(skill));
        context.SaveChanges();
    }

    public void Update(Skill skill)
    {
        var skillDto = context.Skills!.FirstOrDefault(s => s.Id == skill.Id);

        if (skillDto == null)
        {
            throw new NotFoundException($"Skill not found | {skill.Id}");
        }

        skillDto.Name = skill.Name.Value;
        skillDto.Description = skill.Description.Value;
        
        context.SaveChanges();
    }

    public void Delete(Skill skill)
    {
        var skillDto = context.Skills!.FirstOrDefault(s => s.Id == skill.Id);

        if (skillDto == null)
        {
            throw new NotFoundException($"Skill not found | {skill.Id}");
        }
        
        context.Skills!.Remove(skillDto);
        
        context.SaveChanges();
    }

    private SkillEntity SkillToDto(Skill skill)
    {
        return new SkillEntity
        {
            Id = skill.Id,
            Name = skill.Name.Value,
            Description = skill.Description.Value
        };
    }

    private Skill DtoToSkill(SkillEntity entity)
    {
        return skillCreator.Execute(entity.Id, entity.Name, entity.Description);
    }
}