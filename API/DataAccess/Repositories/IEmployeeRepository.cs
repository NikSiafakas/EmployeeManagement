using EmployeeManagementAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAPI.DataAccess.Repositories;

public interface IEmployeeRepository
{
    Task<ActionResult<IEnumerable<EmployeeModel>>> Get();
    Task<ActionResult<EmployeeModel>> GetById(int id);
    Task<EmployeeModel> Post(EmployeeModel employee);
    Task<EmployeeModel> Put(EmployeeModel updated);
    Task Delete(int id);
}