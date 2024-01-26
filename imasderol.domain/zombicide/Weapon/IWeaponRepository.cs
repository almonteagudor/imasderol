using imasderol.domain.zombicide.skill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imasderol.domain.zombicide.weapon
{
    public interface IWeaponRepository
    {
        /// <summary>
        /// Finds a skill by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the weapon to find.</param>
        /// <returns>The wapon with the specified identifier, or throws a <see cref="NotFoundException"/> if not found.</returns>
        /// <exception cref="NotFoundException">Thrown when a weapon with the specified identifier is not found.</exception>
        public Weapon FindById(Guid id);

        /// <summary>
        /// Gets all the weapons in the repository.
        /// </summary>
        /// <returns>An IEnumerable of weapons.</returns>
        public IEnumerable<Weapon> GetAll();

        /// <summary>
        /// Saves a weapon to the repository.
        /// </summary>
        /// <param name="weapon">The weapon to save.</param>
        /// <exception cref="NotSavedException">Thrown when the weapon cannot be saved.</exception>
        /// <exception cref="NotFoundException">Thrown when a weapon with the specified identifier is not found.</exception>
        public void Save(Weapon weapon);

        /// <summary>
        /// Updates an existing weapon in the repository.
        /// </summary>
        /// <param name="weapon">The weapon to update.</param>
        /// <exception cref="NotUpdatedException">Thrown when the weapon cannot be updated.</exception>
        /// <exception cref="NotFoundException">Thrown when a weapon with the specified identifier is not found.</exception>
        public void Update(Weapon weapon);

        /// <summary>
        /// Deletes a weapon from the repository.
        /// </summary>
        /// <param name="weapon">The weapon to delete.</param>
        /// <exception cref="NotDeletedException">Thrown when the weapon cannot be deleted.</exception>
        /// <exception cref="NotFoundException">Thrown when a weapon with the specified identifier is not found.</exception>
        public void Delete(Weapon weapon);
    }
}
