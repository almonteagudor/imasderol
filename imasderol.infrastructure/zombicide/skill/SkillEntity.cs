using System.ComponentModel.DataAnnotations;

namespace imasderol.infrastructure.zombicide.skill;

public class SkillEntity
{
    public Guid Id { get; init; }
    
    [MinLength(domain.shared.valueObjects.Name.MinLength)]
    [MaxLength(domain.shared.valueObjects.Name.MaxLength)]
    public string Name { get; set; } = "";
    
    [MaxLength(domain.shared.valueObjects.Description.MaxLength)]
    public string Description { get; set; } = "";
}