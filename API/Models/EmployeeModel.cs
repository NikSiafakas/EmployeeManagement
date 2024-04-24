using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementAPI.Models;

public class EmployeeModel
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Surname { get; set; }
    [Required]
    public string Email { get; set; }
    public string Phone { get; set; }
    [Required]
    public DateTime Hired { get; set; }
    public string Skillset { get; set; }
    public DateTime SkillsetUpdated { get; set; }

    public List<int> SkillsetList
    {
        get => String.IsNullOrWhiteSpace(Skillset) ? new List<int>() : Skillset.Split(',').Select(a => int.Parse(a)).ToList();
    }
}
