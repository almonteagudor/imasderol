using imasderol.domain.shared.valueObjects;

namespace imasderol.domain.zombicide.skill;

public class Skill(Guid id, Name name, Description description)
{
    public Guid Id { get; init; } = id;
    public Name Name { get; set; } = name;
    public Description Description { get; set; } = description;
}