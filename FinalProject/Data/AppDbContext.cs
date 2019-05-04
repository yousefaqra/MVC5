using FinalProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<GroupsSetup> Groups { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<GroupsSetup>().HasData(

              new GroupsSetup()
              {
                  ID = 1,
                  Code = "A",
                  StartDate = new DateTime(2019, 1, 1),
                  EndDate = new DateTime(2019, 12, 31)
              },
              new GroupsSetup()
              {
                  ID = 2,
                  Code = "B",
                  StartDate = new DateTime(2019, 1, 1),
                  EndDate = new DateTime(2019, 12, 31)
              },
              new GroupsSetup()
              {
                  ID = 3,
                  Code = "C",
                  StartDate = new DateTime(2019, 1, 1),
                  EndDate = new DateTime(2019, 12, 31)
              }
              );

            modelBuilder.Entity<Student>().HasData(

              new Student()
              {
                  ZajelID = 11317076,
                  FirstName = "Khaled",
                  LastName = "Ismaeel",
                  GDPA = 2.5,
                  Gender ='M',
                  NumberOFHourse = 255,
                  Adress = "Nablus",
                  Toofel = true,
                  GroupID = 1
              },
               new Student()
               {
                   ZajelID = 11417076,
                   FirstName = "Lara",
                   LastName = "Saka",
                   GDPA = 3.5,
                   Gender = 'F',
                   NumberOFHourse = 255,
                   Adress = "Rammallah",
                   Toofel = true,
                   GroupID = 2
               },
               new Student()
               {
                   ZajelID = 11517076,
                   FirstName = "Osama",
                   LastName = "Mara",
                   GDPA = 2.7,
                   Gender = 'M',
                   NumberOFHourse = 255,
                   Adress = "Biddya",
                   Toofel = true,
                   GroupID = 3
               }
              );

            modelBuilder.Entity<Course>(b =>
            {
                b.HasData(new
                {
                    ID = 1,
                    Name = "Internal Medicine",
                    Date = new DateTime(2019, 1, 1),
                    GroupID = 1,
                });

                b.OwnsOne(e => e.Doctor).HasData(new
                {
                    ID = 1,
                    Code = "IM1",
                    FirstName = "Ramez",
                    LastName = "Rabi",
                    Specialization = "Internal Medicine",
                    Hospital = "NNU",
                    isDeleted = false,
                    CourseID = 1,
                });
            });

        }
    }


}
