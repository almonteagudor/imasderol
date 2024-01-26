using imasderol.domain.zombicide.Weapon;

namespace imasderol.application.zombicide.weapons.getWeaponsQuery;

public class GetWeaponsQueryHandler(IWeaponRepository repository)
{
    /// <summary>
    /// Gets all weapons.
    /// </summary>
    /// <returns>An IEnumerable of weapons.</returns>
    public IEnumerable<Weapon> Execute()
    {
        return repository.GetAll();
    }
}