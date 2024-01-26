using imasderol.application.zombicide.skill.createSkillCommand;
using imasderol.application.zombicide.skill.deleteSkillCommand;
using imasderol.application.zombicide.skill.findSkillByIdQuery;
using imasderol.application.zombicide.skill.getSkillsQuery;
using imasderol.application.zombicide.skill.updateSkillCommand;
using imasderol.domain.shared.exceptions;
using imasderol.domain.zombicide.skill;
using Microsoft.AspNetCore.Mvc;

namespace imasderol.api.zombicide.skill;

[Route("api/[controller]")]
[ApiController]
public class SkillController : ControllerBase
{
    [HttpGet]
    public IEnumerable<Skill> GetSkills([FromServices] GetSkillsQueryHandler handler)
    {
        return handler.Execute();
    }

    [HttpGet("{id}")]
    public ActionResult<Skill> FindSkillById(string id, [FromServices] FindSkillByIdQueryHandler handler)
    {
        try
        {
            var skill = handler.Execute(new FindSkillByIdQuery(id));

            return skill;
        }
        catch (NotFoundException exception)
        {
            return NotFound(exception.Message);
        }
    }

    [HttpPost]
    public ActionResult<Skill> CreateSkill([FromBody] CreateSkillCommand command, [FromServices] CreateSkillCommandHandler handler)
    {
        try
        {
            var skill = handler.Execute(command);

            return Created((string?)null, skill);
        }
        catch (ValidationException exception)
        {
            return BadRequest(exception.Messages);
        }
        catch (NotSavedException exception)
        {
            return Conflict(exception.Message);
        }
    }

    [HttpPut("{id}")]
    public ActionResult<Skill> UpdateSkill(string id, [FromBody] UpdateSkillCommand command, [FromServices] UpdateSkillCommandHandler handler)
    {
        try
        {
            var skill = handler.Execute(command with { Id = id });

            return skill;
        }
        catch (ValidationException exception)
        {
            return BadRequest(exception.Messages);
        }
        catch (NotUpdatedException exception)
        {
            return Conflict(exception.Message);
        }
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteSkill(string id, [FromServices] DeleteSkillCommandHandler handler)
    {
        try
        {
            handler.Execute(new DeleteSkillCommand(id));

            return NoContent();
        }
        catch (NotFoundException exception)
        {
            return NotFound(exception.Message);
        }
        catch (NotDeletedException exception)
        {
            return Conflict(exception.Message);
        }
    }
}