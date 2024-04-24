using EmployeeManagementAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAPI.DataAccess.Repositories;

public interface ISkillRepository
{
    Task<ActionResult<IEnumerable<SkillModel>>> Get();
    Task<ActionResult<SkillModel>> GetById(int id);
    Task<SkillModel> Post(SkillModel skill);
    Task<SkillModel> Put(SkillModel updated);
    Task Delete(int id);
}