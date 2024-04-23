using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementAPI.Models;

public class EmployeeModel
{
    public int Id { get; set; }                 // PK
    [Required]
    public string Name { get; set; }
    [Required]
    public string Surname { get; set; }
    [Required]
    public string Email { get; set; }
    public string Phone { get; set; }
    public IList<int> Skillset { get; set; }    // FK

    [Required]
    public string Hired {
        get { return _hired.ToString("yyyy-MM-dd"); }
        set { _hired = DateTime.Parse(value); }
    }
    private DateTime _hired;
    //public DateTime Hired { get; set; }

    public string SkillsetUpdated
    {
        get { return _skillsetUpdated.ToString("yyyy-MM-dd"); }
        set { _skillsetUpdated = DateTime.Parse(value); }
    }
    private DateTime _skillsetUpdated;
    //public DateTime SkillsetUpdated { get; set; }
}
