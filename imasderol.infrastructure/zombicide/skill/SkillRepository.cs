using imasderol.domain.shared.exceptions;
using imasderol.domain.shared.valueObjects;
using imasderol.domain.zombicide.skill;
using Microsoft.EntityFrameworkCore;

namespace imasderol.infrastructure.zombicide.skill;

public class SkillRepository(ImasderolDb context) : ISkillRepository
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

    public IEnumerable<Skill> FindAll()
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
        
        context.Entry(skillDto).State = EntityState.Modified;
        context.SaveChanges();
    }

    public void Delete(Skill skill)
    {
        var skillDto = context.Skills!.FirstOrDefault(s => s.Id == skill.Id);

        if (skillDto == null)
        {
            throw new NotFoundException($"Skill not found | {skill.Id}");
        }
        
        context.Entry(skillDto).State = EntityState.Deleted;
        context.SaveChanges();
    }

    private SkillDto SkillToDto(Skill skill)
    {
        return new SkillDto
        {
            Id = skill.Id,
            Name = skill.Name.Value,
            Description = skill.Description.Value
        };
    }

    private Skill DtoToSkill(SkillDto dto)
    {
        return new Skill(dto.Id, new Name(dto.Name!), new Description(dto.Description!));
    }
}