using EmployeeManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementAPI.DataAccess.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly DbContext_SqlServer _context;
    public EmployeeRepository(DbContext_SqlServer dbContext_SqlServer)
    {
        this._context = dbContext_SqlServer;
    }


    public async Task<IEnumerable<EmployeeModel>> Get()
    {
        return _context.Employees;
    }

    public async Task<EmployeeModel> GetById(int id)
    {
        var employee = await _context.Employees.SingleOrDefaultAsync(a => a.Id == id);
        if (employee == null)
            throw new Exception("NotFound");

        return employee;
    }

    public async Task<EmployeeModel> Post(EmployeeModel employee)
    {
        employee.Id = 0;
        employee.SkillsetUpdated = DateTime.UtcNow;
        await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();
        return employee;
    }

    public async Task<EmployeeModel> Put(EmployeeModel updated)
    {
        var employee = await _context.Employees.SingleOrDefaultAsync(a => a.Id == updated.Id);
        if (employee == null)
            throw new Exception("NotFound");

        employee.Name = updated.Name;
        employee.Surname = updated.Surname;
        employee.Email = updated.Email;
        employee.Phone = updated.Phone;
        employee.Hired = updated.Hired;

        var skillsWereAdded = updated.SkillsetList.Any(newSkill => !employee.SkillsetList.Contains(newSkill));
        var skillsWereRemoved = employee.SkillsetList.Any(oldSkill => !updated.SkillsetList.Contains(oldSkill));
        if (skillsWereAdded || skillsWereRemoved)
        {
            employee.Skillset = updated.Skillset;
            employee.SkillsetUpdated = DateTime.UtcNow;
        }
        await _context.SaveChangesAsync();

        return employee;
    }

    public async Task Delete(int id)
    {
        var employee = await _context.Employees.SingleOrDefaultAsync(a => a.Id == id);
        if (employee == null)
            throw new Exception("NotFound");

        _context.Employees.Remove(employee);
        await _context.SaveChangesAsync();
    }
}
