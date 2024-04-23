using EmployeeManagementAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    static List<EmployeeModel> employees = new List<EmployeeModel>
    {
        new() { Id=1, Name="Jon",Surname="Snow", Email="jsnow@gmail.com", Phone="2104545123", Skillset = new List<int> { 3, 4, 5 }, Hired = "2012/11/04", SkillsetUpdated = "2022/12/27" },
        new() { Id=2, Name="Jenny",Surname="Sharp", Email="jsharp@gmail.com", Phone="2106848641", Skillset = new List<int> { 1, 2 }, Hired = "2013/10/30", SkillsetUpdated = "2023/11/24" },
        new() { Id=3, Name="Anny",Surname="Simpson", Email="asmp@gmail.com", Phone="2104549955", Skillset = new List<int> { 1, 2, 5 }, Hired = "2014/01/20", SkillsetUpdated = "2022/02/20" },
        new() { Id=4, Name="James",Surname="Dean", Email="jd@gmail.com", Phone="2104752123", Skillset = new List<int> { 5 }, Hired = "2015/10/23", SkillsetUpdated = "2019/11/02" },
        new() { Id=5, Name="Danny",Surname="Reed", Email="dreed@gmail.com", Phone="2108945123", Skillset = new List<int> { 1, 4, 5 }, Hired = "2016/07/15", SkillsetUpdated = "2020/11/20" },
        new() { Id=6, Name="Chris",Surname="Brown", Email="cbn@gmail.com", Phone="2104545463", Skillset = new List<int> { 2, 5 }, Hired = "2017/05/13", SkillsetUpdated = "2021/05/20" },
        new() { Id=7, Name="Ella",Surname="Green", Email="egr@gmail.com", Phone="2104577723", Skillset = new List<int> { 2, 3, 4, 5 }, Hired = "2018/02/03", SkillsetUpdated = "2022/11/02" },
        new() { Id=8, Name="Rick",Surname="Free", Email="rfree@gmail.com", Phone="2104524823", Skillset = new List<int> { 1, 2, 3, 4, 5 }, Hired = "2019/03/02", SkillsetUpdated = "2022/01/20" }
        //new EmployeeModel { Id=1, Name="Jon",Surname="Snow", Email="jsnow@gmail.com", Phone="2104545123", Skillset = new List<int> { 3, 4, 5 }, Hired = DateTime.Parse("2012/11/04"), SkillsetUpdated = DateTime.Parse("2022/12/27") },
        //new EmployeeModel { Id=2, Name="Jenny",Surname="Sharp", Email="jsharp@gmail.com", Phone="2106848641", Skillset = new List<int> { 1, 2 }, Hired = DateTime.Parse("2013/10/30"), SkillsetUpdated = DateTime.Parse("2023/11/24") },
        //new EmployeeModel { Id=3, Name="Anny",Surname="Simpson", Email="asmp@gmail.com", Phone="2104549955", Skillset = new List<int> { 1, 2, 5 }, Hired = DateTime.Parse("2014/01/20"), SkillsetUpdated = DateTime.Parse("2022/02/20") },
        //new EmployeeModel { Id=4, Name="James",Surname="Dean", Email="jd@gmail.com", Phone="2104752123", Skillset = new List<int> { 5 }, Hired = DateTime.Parse("2015/10/23"), SkillsetUpdated = DateTime.Parse("2019/11/02") },
        //new EmployeeModel { Id=5, Name="Danny",Surname="Reed", Email="dreed@gmail.com", Phone="2108945123", Skillset = new List<int> { 1, 4, 5 }, Hired = DateTime.Parse("2016/07/15"), SkillsetUpdated = DateTime.Parse("2020/11/20") },
        //new EmployeeModel { Id=6, Name="Chris",Surname="Brown", Email="cbn@gmail.com", Phone="2104545463", Skillset = new List<int> { 2, 5 }, Hired = DateTime.Parse("2017/05/13"), SkillsetUpdated = DateTime.Parse("2021/05/20") },
        //new EmployeeModel { Id=7, Name="Ella",Surname="Green", Email="egr@gmail.com", Phone="2104577723", Skillset = new List<int> { 2, 3, 4, 5 }, Hired = DateTime.Parse("2018/02/03"), SkillsetUpdated = DateTime.Parse("2022/11/02") },
        //new EmployeeModel { Id=8, Name="Rick",Surname="Free", Email="rfree@gmail.com", Phone="2104524823", Skillset = new List<int> { 1, 2, 3, 4, 5 }, Hired = DateTime.Parse("2019/03/02"), SkillsetUpdated = DateTime.Parse("2022/01/20") }
    };

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EmployeeModel>>> Get()
    {
        return employees.Any() ? employees : NotFound();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EmployeeModel>> GetById(int id)
    {
        var employee = employees.SingleOrDefault(a => a.Id == id);
        return (employee != null) ? employee : NotFound();
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] EmployeeModel employee)
    {
        if (employee == null)
            return BadRequest();

        employee.Id = employees.Max(a => a.Id) + 1;
        employee.SkillsetUpdated = DateTime.Now.ToString();
        employees.Add(employee);

        return CreatedAtAction(nameof(GetById), new { id = employee.Id }, null);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] EmployeeModel updated)
    {
        if (updated == null)
            return BadRequest();

        var employee = employees.SingleOrDefault(a => a.Id == id);
        if (employee == null)
            return NotFound();

        employee.Name = updated.Name;
        employee.Surname = updated.Surname;
        employee.Email = updated.Email;
        employee.Phone = updated.Phone;
        employee.Hired = updated.Hired;

        var skillsWereAdded = updated.Skillset.Any(newSkill => !employee.Skillset.Contains(newSkill));
        var skillsWereRemoved = employee.Skillset.Any(oldSkill => !updated.Skillset.Contains(oldSkill));
        if (skillsWereAdded || skillsWereRemoved)
        {
            employee.Skillset = updated.Skillset;
            employee.SkillsetUpdated = DateTime.Now.ToString();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var index = employees.FindIndex(a => a.Id == id);
        if (index < 0)
            return NotFound();

        employees.RemoveAt(index);

        return NoContent();
    }
}
