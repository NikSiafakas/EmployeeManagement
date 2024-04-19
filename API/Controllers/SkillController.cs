using EmployeeManagementAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SkillController : ControllerBase
{
    static List<SkillModel> skills = new List<SkillModel>
    {
        new SkillModel { Id = 1, Name = "Engineering", Description = "Understanding systems deeply", Created = DateTime.Parse("2012/11/20") },
        new SkillModel { Id = 2, Name = "Planning", Description = "Organizing and Prioritizing", Created = DateTime.Parse("2012/04/30") },
        new SkillModel { Id = 3, Name = "Negotiating", Description = "Securing favorable deals", Created = DateTime.Parse("2014/01/05") },
        new SkillModel { Id = 4, Name = "Leadership", Description = "Managing and leading people", Created = DateTime.Parse("2013/12/12") },
        new SkillModel { Id = 5, Name = "Problem-solving", Description = "Finding valuable solutions", Created = DateTime.Parse("2014/10/10") },
        new SkillModel { Id = 6, Name = "Writing", Description = "Creating articulate scripts", Created = DateTime.Parse("2015/10/02") }
    };


    [HttpGet]
    public async Task<ActionResult<IEnumerable<SkillModel>>> Get()
    {
        return skills.Any() ? skills : NotFound();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SkillModel>> GetById(int id)
    {
        var skill = skills.SingleOrDefault(a => a.Id == id);
        return (skill != null) ? skill : NotFound();
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] SkillModel skill)
    {
        if (skill == null)
            return BadRequest();

        skill.Id = skills.Max(a => a.Id) + 1;
        skills.Add(skill);
        return CreatedAtAction(nameof(GetById), new { id = skill.Id }, null);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] SkillModel updated)
    {
        if (updated == null)
            return BadRequest();

        var skill = skills.SingleOrDefault(a => a.Id == id);
        if (skill == null)
            return NotFound();

        skill.Name = updated.Name;
        skill.Description = updated.Description;            //  this enough ???

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var index = skills.FindIndex(a => a.Id == id);
        if (index < 0)
            return NotFound();

        skills.RemoveAt(index);

        return NoContent();
    }
}
