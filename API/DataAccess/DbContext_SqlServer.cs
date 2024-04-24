using EmployeeManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementAPI.DataAccess;

public class DbContext_SqlServer : DbContext
{
    public DbContext_SqlServer(DbContextOptions<DbContext_SqlServer> options) : base(options) { }

    public DbSet<EmployeeModel> Employees => Set<EmployeeModel>();
    public DbSet<SkillModel> Skills => Set<SkillModel>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SkillModel>().HasData(
            new SkillModel { Id = 1, Name = "Engineering", Description = "Understanding systems deeply", Created = DateTime.Parse("2012/11/20") },
            new SkillModel { Id = 2, Name = "Planning", Description = "Organizing and Prioritizing", Created = DateTime.Parse("2012/04/30") },
            new SkillModel { Id = 3, Name = "Negotiating", Description = "Securing favorable deals", Created = DateTime.Parse("2014/01/05") },
            new SkillModel { Id = 4, Name = "Leadership", Description = "Managing and leading people", Created = DateTime.Parse("2013/12/12") },
            new SkillModel { Id = 5, Name = "Problem-solving", Description = "Finding valuable solutions", Created = DateTime.Parse("2014/10/10") },
            new SkillModel { Id = 6, Name = "Writing", Description = "Creating articulate scripts", Created = DateTime.Parse("2015/10/02") }
        );
        modelBuilder.Entity<EmployeeModel>().HasData(
            new EmployeeModel { Id = 1, Name = "Jon", Surname = "Snow", Email = "jsnow@gmail.com", Phone = "2104545123", Skillset = string.Join(',', new List<int> { 3, 4, 5 }), Hired = DateTime.Parse("2012/11/04"), SkillsetUpdated = DateTime.Parse("2022/12/27") },
            new EmployeeModel { Id = 2, Name = "Jenny", Surname = "Sharp", Email = "jsharp@gmail.com", Phone = "2106848641", Skillset = string.Join(',', new List<int> { 1, 2 }), Hired = DateTime.Parse("2013/10/30"), SkillsetUpdated = DateTime.Parse("2023/11/24") },
            new EmployeeModel { Id = 3, Name = "Anny", Surname = "Simpson", Email = "asmp@gmail.com", Phone = "2104549955", Skillset = string.Join(',', new List<int> { 1, 2, 5 }), Hired = DateTime.Parse("2014/01/20"), SkillsetUpdated = DateTime.Parse("2022/02/20") },
            new EmployeeModel { Id = 4, Name = "James", Surname = "Dean", Email = "jd@gmail.com", Phone = "2104752123", Skillset = string.Join(',', new List<int> { 5 }), Hired = DateTime.Parse("2015/10/23"), SkillsetUpdated = DateTime.Parse("2019/11/02") },
            new EmployeeModel { Id = 5, Name = "Danny", Surname = "Reed", Email = "dreed@gmail.com", Phone = "2108945123", Skillset = string.Join(',', new List<int> { 1, 4, 5 }), Hired = DateTime.Parse("2016/07/15"), SkillsetUpdated = DateTime.Parse("2020/11/20") },
            new EmployeeModel { Id = 6, Name = "Chris", Surname = "Brown", Email = "cbn@gmail.com", Phone = "2104545463", Skillset = string.Join(',', new List<int> { 2, 5 }), Hired = DateTime.Parse("2017/05/13"), SkillsetUpdated = DateTime.Parse("2021/05/20") },
            new EmployeeModel { Id = 7, Name = "Ella", Surname = "Green", Email = "egr@gmail.com", Phone = "2104577723", Skillset = string.Join(',', new List<int> { 2, 3, 4, 5 }), Hired = DateTime.Parse("2018/02/03"), SkillsetUpdated = DateTime.Parse("2022/11/02") },
            new EmployeeModel { Id = 8, Name = "Rick", Surname = "Free", Email = "rfree@gmail.com", Phone = "2104524823", Skillset = string.Join(',', new List<int> { 1, 2, 3, 4, 5 }), Hired = DateTime.Parse("2019/03/02"), SkillsetUpdated = DateTime.Parse("2022/01/20") }
        );

        base.OnModelCreating(modelBuilder);
    }
}
