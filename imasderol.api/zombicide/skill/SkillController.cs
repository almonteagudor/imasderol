using imasderol.application.zombicide.skill.createSkillCommand;
using imasderol.application.zombicide.skill.deleteSkillCommand;
using imasderol.application.zombicide.skill.findSkillByIdQuery;
using imasderol.application.zombicide.skill.getSkillsQuery;
using imasderol.domain.shared.exceptions;
using Microsoft.AspNetCore.Mvc;

namespace imasderol.api.zombicide.skill;

[Route("api/[controller]")]
[ApiController]
public class SkillController : ControllerBase
{
    [HttpGet]
    public IEnumerable<SkillDto> GetSkills([FromServices] GetSkillsQueryHandler handler)
    {
        return handler.Execute().ToList().Select(
            skill => new SkillDto(skill.Id.ToString(), skill.Name.Value, skill.Description.Value)
        );
    }

    [HttpGet("{id}")]
    public ActionResult<SkillDto> FindSkillById(string id, [FromServices] FindSkillByIdQueryHandler handler)
    {
        try
        {
            var skill = handler.Execute(new FindSkillByIdQuery(id));

            return new SkillDto(skill.Id.ToString(), skill.Name.Value, skill.Description.Value);
        }
        catch (NotFoundException exception)
        {
            return NotFound(exception.Message);
        }
    }

    [HttpPost]
    public ActionResult<SkillDto> CreateSkill([FromBody] CreateSkillCommand command, [FromServices] CreateSkillCommandHandler handler)
    {
        try
        {
            var skill = handler.Execute(command);

            return Created((string?)null, new SkillDto(skill.Id.ToString(), skill.Name.Value, skill.Description.Value));
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
    public ActionResult<SkillDto> UpdateSkill(string id, [FromBody] UpdateSkillCommand command, [FromServices] UpdateSkillCommandHandler handler)
    {
        try
        {
            var skill = handler.Execute(command with { Id = Guid.Parse(id) });

            return new SkillDto(skill.Id.ToString(), skill.Name.Value, skill.Description.Value);
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