﻿using imasderol.domain.shared.exceptions;
using imasderol.domain.zombicide.skill;

namespace imasderol.application.zombicide.skill.updateSkillCommand;

public class UpdateSkillCommandHandler(ISkillRepository repository)
{
    /// <summary>
    /// Executes the creation of a new skill based on the provided CreateSkillCommand.
    /// </summary>
    /// <param name="skillCommand">The CreateSkillCommand containing skill details.</param>
    /// <returns>The created Skill instance.</returns>
    /// <exception cref="NotUpdatedException">Thrown when the skill cannot be saved.</exception>
    /// <exception cref="ValidationException">Thrown if there are validation errors in the name or description parameters.</exception>
    public Skill Execute(UpdateSkillCommand skillCommand)
    {
        var skill = new Skill(skillCommand.Id, skillCommand.Name, skillCommand.Description);
        
        repository.Update(skill);

        return skill;
    }
}