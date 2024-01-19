using imasderol.domain.shared.exceptions;

namespace imasderol.domain.zombicide.skill;

public interface ISkillRepository
{
    /// <summary>
    /// Finds a skill by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the skill to find.</param>
    /// <returns>The skill with the specified identifier, or throws a <see cref="NotFoundException"/> if not found.</returns>
    /// <exception cref="NotFoundException">Thrown when a skill with the specified identifier is not found.</exception>
    public Skill FindById(Guid id);
    
    /// <summary>
    /// Gets all skills in the repository.
    /// </summary>
    /// <returns>An IEnumerable of skills.</returns>
    public IEnumerable<Skill> GetAll();
    
    /// <summary>
    /// Saves a skill to the repository.
    /// </summary>
    /// <param name="skill">The skill to save.</param>
    /// <exception cref="NotSavedException">Thrown when the skill cannot be saved.</exception>
    /// <exception cref="NotFoundException">Thrown when a skill with the specified identifier is not found.</exception>
    public void Save(Skill skill);
    
    /// <summary>
    /// Updates an existing skill in the repository.
    /// </summary>
    /// <param name="skill">The skill to update.</param>
    /// <exception cref="NotUpdatedException">Thrown when the skill cannot be updated.</exception>
    /// <exception cref="NotFoundException">Thrown when a skill with the specified identifier is not found.</exception>
    public void Update(Skill skill);
    
    /// <summary>
    /// Deletes a skill from the repository.
    /// </summary>
    /// <param name="skill">The skill to delete.</param>
    /// <exception cref="NotDeletedException">Thrown when the skill cannot be deleted.</exception>
    /// <exception cref="NotFoundException">Thrown when a skill with the specified identifier is not found.</exception>
    public void Delete(Skill skill);
}