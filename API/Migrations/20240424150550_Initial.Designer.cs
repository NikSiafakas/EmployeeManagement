﻿// <auto-generated />
using System;
using EmployeeManagementAPI.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmployeeManagementAPI.Migrations
{
    [DbContext(typeof(DbContext_SqlServer))]
    [Migration("20240424150550_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EmployeeManagementAPI.Models.EmployeeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Hired")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Skillset")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SkillsetUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "jsnow@gmail.com",
                            Hired = new DateTime(2012, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Jon",
                            Phone = "2104545123",
                            Skillset = "3,4,5",
                            SkillsetUpdated = new DateTime(2022, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Surname = "Snow"
                        },
                        new
                        {
                            Id = 2,
                            Email = "jsharp@gmail.com",
                            Hired = new DateTime(2013, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Jenny",
                            Phone = "2106848641",
                            Skillset = "1,2",
                            SkillsetUpdated = new DateTime(2023, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Surname = "Sharp"
                        },
                        new
                        {
                            Id = 3,
                            Email = "asmp@gmail.com",
                            Hired = new DateTime(2014, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Anny",
                            Phone = "2104549955",
                            Skillset = "1,2,5",
                            SkillsetUpdated = new DateTime(2022, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Surname = "Simpson"
                        },
                        new
                        {
                            Id = 4,
                            Email = "jd@gmail.com",
                            Hired = new DateTime(2015, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "James",
                            Phone = "2104752123",
                            Skillset = "5",
                            SkillsetUpdated = new DateTime(2019, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Surname = "Dean"
                        },
                        new
                        {
                            Id = 5,
                            Email = "dreed@gmail.com",
                            Hired = new DateTime(2016, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Danny",
                            Phone = "2108945123",
                            Skillset = "1,4,5",
                            SkillsetUpdated = new DateTime(2020, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Surname = "Reed"
                        },
                        new
                        {
                            Id = 6,
                            Email = "cbn@gmail.com",
                            Hired = new DateTime(2017, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Chris",
                            Phone = "2104545463",
                            Skillset = "2,5",
                            SkillsetUpdated = new DateTime(2021, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Surname = "Brown"
                        },
                        new
                        {
                            Id = 7,
                            Email = "egr@gmail.com",
                            Hired = new DateTime(2018, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Ella",
                            Phone = "2104577723",
                            Skillset = "2,3,4,5",
                            SkillsetUpdated = new DateTime(2022, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Surname = "Green"
                        },
                        new
                        {
                            Id = 8,
                            Email = "rfree@gmail.com",
                            Hired = new DateTime(2019, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Rick",
                            Phone = "2104524823",
                            Skillset = "1,2,3,4,5",
                            SkillsetUpdated = new DateTime(2022, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Surname = "Free"
                        });
                });

            modelBuilder.Entity("EmployeeManagementAPI.Models.SkillModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Skills");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2012, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Understanding systems deeply",
                            Name = "Engineering"
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2012, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Organizing and Prioritizing",
                            Name = "Planning"
                        },
                        new
                        {
                            Id = 3,
                            Created = new DateTime(2014, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Securing favorable deals",
                            Name = "Negotiating"
                        },
                        new
                        {
                            Id = 4,
                            Created = new DateTime(2013, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Managing and leading people",
                            Name = "Leadership"
                        },
                        new
                        {
                            Id = 5,
                            Created = new DateTime(2014, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Finding valuable solutions",
                            Name = "Problem-solving"
                        },
                        new
                        {
                            Id = 6,
                            Created = new DateTime(2015, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Creating articulate scripts",
                            Name = "Writing"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
