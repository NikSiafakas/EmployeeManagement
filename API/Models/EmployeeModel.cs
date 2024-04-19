namespace EmployeeManagementAPI.Models;

public class EmployeeModel
{
    public int Id { get; set; }                 // PK
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public IList<int> Skillset { get; set; }    // FK   ---> OR should this be IList<SkillModel> ???
    public DateTime Hired { get; set; }
    public DateTime SkillsetUpdated { get; set; }
}
