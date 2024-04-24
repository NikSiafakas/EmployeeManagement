using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagementAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hired = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Skillset = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SkillsetUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "Hired", "Name", "Phone", "Skillset", "SkillsetUpdated", "Surname" },
                values: new object[,]
                {
                    { 1, "jsnow@gmail.com", new DateTime(2012, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jon", "2104545123", "3,4,5", new DateTime(2022, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Snow" },
                    { 2, "jsharp@gmail.com", new DateTime(2013, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jenny", "2106848641", "1,2", new DateTime(2023, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sharp" },
                    { 3, "asmp@gmail.com", new DateTime(2014, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anny", "2104549955", "1,2,5", new DateTime(2022, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Simpson" },
                    { 4, "jd@gmail.com", new DateTime(2015, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "James", "2104752123", "5", new DateTime(2019, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dean" },
                    { 5, "dreed@gmail.com", new DateTime(2016, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Danny", "2108945123", "1,4,5", new DateTime(2020, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reed" },
                    { 6, "cbn@gmail.com", new DateTime(2017, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chris", "2104545463", "2,5", new DateTime(2021, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brown" },
                    { 7, "egr@gmail.com", new DateTime(2018, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ella", "2104577723", "2,3,4,5", new DateTime(2022, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Green" },
                    { 8, "rfree@gmail.com", new DateTime(2019, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rick", "2104524823", "1,2,3,4,5", new DateTime(2022, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Free" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Created", "Description", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2012, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Understanding systems deeply", "Engineering" },
                    { 2, new DateTime(2012, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Organizing and Prioritizing", "Planning" },
                    { 3, new DateTime(2014, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Securing favorable deals", "Negotiating" },
                    { 4, new DateTime(2013, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Managing and leading people", "Leadership" },
                    { 5, new DateTime(2014, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Finding valuable solutions", "Problem-solving" },
                    { 6, new DateTime(2015, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Creating articulate scripts", "Writing" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Skills");
        }
    }
}
