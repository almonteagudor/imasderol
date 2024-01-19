using imasderol.application.zombicide.skill;
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
    public IActionResult FindSkillById(string id, [FromServices] FindSkillByIdQueryHandler handler)
    {
        try
        {
            var skill = handler.Execute(new FindSkillByIdQuery(id));

            return Ok(new SkillDto(skill.Id.ToString(), skill.Name.Value, skill.Description.Value));
        }
        catch (NotFoundException exception)
        {
            return NotFound(exception.Message);
        }
    }

    [HttpPost]
    public SkillDto CreateSkill([FromBody] CreateSkillCommand command, [FromServices] CreateSkillCommandHandler handler)
    {
        var skill = handler.Execute(command);
        
        return new SkillDto(skill.Id.ToString(), skill.Name.Value, skill.Description.Value);
    }

    //
    // // PUT api/<SkillController>/5
    // [HttpPut("{id}")]
    // public void Put(int id, [FromBody] string value)
    // {
    // }
    
    [HttpDelete("{id}")]
    public void DeleteSkill(string id, [FromServices] DeleteSkillCommandHandler handler)
    {
        handler.Execute(new DeleteSkillCommand(id));
    }
}