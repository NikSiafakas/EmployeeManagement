using EmployeeManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementAPI.DataAccess.Repositories;

public class SkillRepository : ISkillRepository
{
    private readonly DbContext_SqlServer _context;
    public SkillRepository(DbContext_SqlServer dbContext_SqlServer)
    {
        this._context = dbContext_SqlServer;
    }


    public async Task<IEnumerable<SkillModel>> Get()
    {
        return _context.Skills;
    }

    public async Task<SkillModel> GetById(int id)
    {
        var skill = await _context.Skills.SingleOrDefaultAsync(a => a.Id == id);
        if (skill == null)
            throw new Exception("NotFound");

        return skill;
    }

    public async Task<SkillModel> Post(SkillModel skill)
    {
        skill.Id = 0;
        skill.Created = DateTime.UtcNow;
        await _context.Skills.AddAsync(skill);
        await _context.SaveChangesAsync();
        return skill;
    }

    public async Task<SkillModel> Put(SkillModel updated)
    {
        var skill = await _context.Skills.SingleOrDefaultAsync(a => a.Id == updated.Id);
        if (skill == null)
            throw new Exception("NotFound");

        skill.Name = updated.Name;
        skill.Description = updated.Description;
        await _context.SaveChangesAsync();
        return skill;
    }

    public async Task Delete(int id)
    {
        var skill = await _context.Skills.SingleOrDefaultAsync(a => a.Id == id);
        if (skill == null)
            throw new Exception("NotFound");

        _context.Skills.Remove(skill);
        await _context.SaveChangesAsync();
    }
}
