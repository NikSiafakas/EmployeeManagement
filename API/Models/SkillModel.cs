using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementAPI.Models;

public class SkillModel
{
    public int Id { get; set; }                 // PK
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    public DateTime Created { get; set; }
}
