using imasderol.application.zombicide.skill.createSkillCommand;
using imasderol.application.zombicide.skill.deleteSkillCommand;
using imasderol.application.zombicide.skill.findSkillByIdQuery;
using imasderol.application.zombicide.skill.getSkillsQuery;
using imasderol.domain.shared.exceptions;
using Microsoft.AspNetCore.Mvc;

namespace imasderol.api.zombicide.skill;

[Route("api/[controller]")]
[ApiController]
public class WeaponController : ControllerBase
{
    [HttpGet]
    public IEnumerable<WeaponDTO> GetSkills([FromServices] GetSkillsQueryHandler handler)
    {
        return handler.Execute().ToList().Select(
            weapon => new WeaponDTO()
        );
    }

    [HttpGet("{id}")]
    public ActionResult<WeaponDTO> FindSkillById(string id, [FromServices] FindSkillByIdQueryHandler handler)
    {
        try
        {
            var weapon = handler.Execute(new FindSkillByIdQuery(id));

            return new WeaponDTO();
        }
        catch (NotFoundException exception)
        {
            return NotFound(exception.Message);
        }
    }

    [HttpPost]
    public ActionResult<WeaponDTO> CreateSkill([FromBody] CreateSkillCommand command, [FromServices] CreateSkillCommandHandler handler)
    {
        try
        {
            var weapon = handler.Execute(command);

            return Created((string?)null, new WeaponDTO());
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
    public ActionResult<WeaponDTO> UpdateSkill(string id, [FromBody] UpdateSkillCommand command, [FromServices] UpdateSkillCommandHandler handler)
    {
        try
        {
            var weapon = handler.Execute(command with { Id = Guid.Parse(id) });

            return new WeaponDTO();
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
    public ActionResult DeleteWeapon(string id, [FromServices] DeleteSkillCommandHandler handler)
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