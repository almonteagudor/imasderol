using imasderol.domain.shared.valueObjects;

namespace imasderol.domain.zombicide.skill;

public class Skill
{
    private readonly Guid _id;
    private Name _name = null!;
    private Description _description = null!;

    public Skill(string id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    public string Id
    {
        get => _id.ToString();
        private init => _id = Guid.Parse(value);
    }

    public string Name
    {
        get => _name.Value;
        set => _name = new Name(value);
    }

    public string Description
    {
        get => _description.Value;
        set => _description = new Description(value);
    }
}