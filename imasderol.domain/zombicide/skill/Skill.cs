using imasderol.domain.shared.valueObjects;

namespace imasderol.domain.zombicide.skill;

public class Skill
{
    internal Skill(Guid id, Name name, Description description)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    public Guid Id { get; init; }
    public Name Name { get; set; }
    public Description Description { get; set; }
}