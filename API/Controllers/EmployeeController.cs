using EmployeeManagementAPI.DataAccess.Repositories;
using EmployeeManagementAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeController(IEmployeeRepository employeeRepository)
    {
        this._employeeRepository = employeeRepository;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<EmployeeModel>>> Get()
    {
        try
        {
            var employees = await _employeeRepository.Get();
            return employees.Value.Any() ? employees : NotFound();
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EmployeeModel>> GetById(int id)
    {
        try
        {
            return await _employeeRepository.GetById(id);
        }
        catch (Exception ex)
        {
            return ex.Message.Equals("NotFound") ? NotFound() : Problem(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] EmployeeModel employee)
    {
        if (employee == null)
            return BadRequest();

        try
        {
            var response = await _employeeRepository.Post(employee);
            return CreatedAtAction(nameof(GetById), new { id = response.Id }, null);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult> Put([FromBody] EmployeeModel updated)
    {
        if (updated == null)
            return BadRequest();

        try
        {
            var response = await _employeeRepository.Put(updated);
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
            await _employeeRepository.Delete(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return ex.Message.Equals("NotFound") ? NotFound() : Problem(ex.Message);
        }
    }
}
