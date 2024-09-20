using EmployeeManagementAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAPI.DataAccess.Repositories;

public interface IEmployeeRepository
{
    Task<IEnumerable<EmployeeModel>> Get();
    Task<EmployeeModel> GetById(int id);
    Task<EmployeeModel> Post(EmployeeModel employee);
    Task<EmployeeModel> Put(EmployeeModel updated);
    Task Delete(int id);
}