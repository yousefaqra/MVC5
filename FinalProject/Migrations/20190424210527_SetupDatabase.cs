using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Migrations
{
    public partial class SetupDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Code = table.Column<string>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 40, nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    GroupID = table.Column<int>(nullable: false),
                    GroupCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Courses_Groups_GroupCode",
                        column: x => x.GroupCode,
                        principalTable: "Groups",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    ZajelID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 30, nullable: true),
                    LastName = table.Column<string>(maxLength: 30, nullable: true),
                    Adress = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: false),
                    GDPA = table.Column<double>(nullable: false),
                    Toofel = table.Column<bool>(nullable: false),
                    NumberOFHourse = table.Column<int>(nullable: false),
                    GroupID = table.Column<int>(nullable: false),
                    GroupCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.ZajelID);
                    table.ForeignKey(
                        name: "FK_Students_Groups_GroupCode",
                        column: x => x.GroupCode,
                        principalTable: "Groups",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Code = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 30, nullable: true),
                    LastName = table.Column<string>(maxLength: 30, nullable: true),
                    Specialization = table.Column<string>(nullable: true),
                    Hospital = table.Column<string>(nullable: true),
                    isDeleted = table.Column<bool>(nullable: false),
                    CourseID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Doctors_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_GroupCode",
                table: "Courses",
                column: "GroupCode");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_CourseID",
                table: "Doctors",
                column: "CourseID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_GroupCode",
                table: "Students",
                column: "GroupCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}
