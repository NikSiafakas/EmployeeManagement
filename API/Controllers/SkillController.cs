using EmployeeManagementAPI.DataAccess.Repositories;
using EmployeeManagementAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SkillController : ControllerBase
{
    private readonly ISkillRepository _skillRepository;

    public SkillController(ISkillRepository skillRepository)
    {
        this._skillRepository = skillRepository;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<SkillModel>>> Get()
    {
        try
        {
            var skills = await _skillRepository.Get();
            return skills.Value.Any() ? skills : NotFound();
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SkillModel>> GetById(int id)
    {
        try
        {
            return await _skillRepository.GetById(id);
        }
        catch (Exception ex)
        {
            return ex.Message.Equals("NotFound") ? NotFound() : Problem(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<SkillModel>> Post([FromBody] SkillModel skill)
    {
        if (skill == null)
            return BadRequest();

        try
        {
            var response = await _skillRepository.Post(skill);
            return CreatedAtAction(nameof(GetById), new { id = response.Id }, null);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult<SkillModel>> Put([FromBody] SkillModel updated)
    {
        if (updated == null)
            return BadRequest();

        try
        {
            var response = await _skillRepository.Put(updated);
            return NoContent();
        }
        catch (Exception ex)
        {
            return ex.Message.Equals("NotFound") ? NotFound() : Problem(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            await _skillRepository.Delete(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return ex.Message.Equals("NotFound") ? NotFound() : Problem(ex.Message);
        }
    }
}
