﻿// <auto-generated />
using System;
using FinalProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FinalProject.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FinalProject.Models.Course", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<int>("GroupID");

                    b.Property<int?>("GroupsSetupID");

                    b.Property<string>("Name")
                        .HasMaxLength(40);

                    b.HasKey("ID");

                    b.HasIndex("GroupsSetupID");

                    b.ToTable("Courses");

                    b.HasData(
                        new { ID = 1, Date = new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), GroupID = 1, Name = "Internal Medicine" }
                    );
                });

            modelBuilder.Entity("FinalProject.Models.GroupsSetup", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<DateTime>("EndDate");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("ID");

                    b.ToTable("Groups");

                    b.HasData(
                        new { ID = 1, Code = "A", EndDate = new DateTime(2019, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), StartDate = new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ID = 2, Code = "B", EndDate = new DateTime(2019, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), StartDate = new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ID = 3, Code = "C", EndDate = new DateTime(2019, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), StartDate = new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                    );
                });

            modelBuilder.Entity("FinalProject.Models.Student", b =>
                {
                    b.Property<int>("ZajelID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress");

                    b.Property<string>("FirstName")
                        .HasMaxLength(30);

                    b.Property<double>("GDPA");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)));

                    b.Property<int>("GroupID");

                    b.Property<int?>("GroupsSetupID");

                    b.Property<string>("LastName")
                        .HasMaxLength(30);

                    b.Property<int>("NumberOFHourse");

                    b.Property<bool>("Toofel");

                    b.HasKey("ZajelID");

                    b.HasIndex("GroupsSetupID");

                    b.ToTable("Students");

                    b.HasData(
                        new { ZajelID = 11317076, Adress = "Nablus", FirstName = "Khaled", GDPA = 2.5, Gender = "M", GroupID = 1, LastName = "Ismaeel", NumberOFHourse = 255, Toofel = true },
                        new { ZajelID = 11417076, Adress = "Rammallah", FirstName = "Lara", GDPA = 3.5, Gender = "F", GroupID = 2, LastName = "Saka", NumberOFHourse = 255, Toofel = true },
                        new { ZajelID = 11517076, Adress = "Biddya", FirstName = "Osama", GDPA = 2.7, Gender = "M", GroupID = 3, LastName = "Mara", NumberOFHourse = 255, Toofel = true }
                    );
                });

            modelBuilder.Entity("FinalProject.Models.Course", b =>
                {
                    b.HasOne("FinalProject.Models.GroupsSetup")
                        .WithMany("Courses")
                        .HasForeignKey("GroupsSetupID");

                    b.OwnsOne("FinalProject.Models.Doctor", "Doctor", b1 =>
                        {
                            b1.Property<int>("ID")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Code");

                            b1.Property<string>("FirstName")
                                .HasMaxLength(30);

                            b1.Property<string>("Hospital");

                            b1.Property<string>("LastName")
                                .HasMaxLength(30);

                            b1.Property<string>("Specialization");

                            b1.Property<bool>("isDeleted");

                            b1.ToTable("Courses");

                            b1.HasOne("FinalProject.Models.Course")
                                .WithOne("Doctor")
                                .HasForeignKey("FinalProject.Models.Doctor", "ID")
                                .OnDelete(DeleteBehavior.Cascade);

                            b1.HasData(
                                new { ID = 1, Code = "IM1", FirstName = "Ramez", Hospital = "NNU", LastName = "Rabi", Specialization = "Internal Medicine", isDeleted = false }
                            );
                        });
                });

            modelBuilder.Entity("FinalProject.Models.Student", b =>
                {
                    b.HasOne("FinalProject.Models.GroupsSetup")
                        .WithMany("Students")
                        .HasForeignKey("GroupsSetupID");
                });
#pragma warning restore 612, 618
        }
    }
}