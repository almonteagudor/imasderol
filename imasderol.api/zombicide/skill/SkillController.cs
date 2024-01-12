using imasderol.application.zombicide.skill;
using Microsoft.AspNetCore.Mvc;

namespace imasderol.api.zombicide.skill;

[Route("api/[controller]")]
[ApiController]
public class SkillController : ControllerBase
{
    // [HttpGet]
    // public IEnumerable<string> Get()
    // {
    //     return new string[] { "value1", "value2" };
    // }
    //
    // // GET api/<SkillController>/5
    // [HttpGet("{id}")]
    // public string Get(int id)
    // {
    //     return "value";
    // }

    [HttpPost]
    public CreatedResult Post([FromBody] CreateRequest request, [FromServices] CreateUseCase useCase)
    {
        var skill = useCase.Execute(request);

        return Created((string?)null, skill);
    }

    //
    // // PUT api/<SkillController>/5
    // [HttpPut("{id}")]
    // public void Put(int id, [FromBody] string value)
    // {
    // }
    //
    // // DELETE api/<SkillController>/5
    // [HttpDelete("{id}")]
    // public void Delete(int id)
    // {
    // }
}