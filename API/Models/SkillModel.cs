namespace EmployeeManagementAPI.Models;

public class SkillModel
{
    public int Id { get; set; }                 // PK
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime Created { get; set; }
}
