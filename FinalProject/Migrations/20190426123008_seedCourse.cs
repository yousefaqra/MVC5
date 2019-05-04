using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Migrations
{
    public partial class seedCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Groups_GroupID",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Courses_GroupID",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "GroupsSetupID",
                table: "Courses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Doctor_Code",
                table: "Courses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Doctor_FirstName",
                table: "Courses",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Doctor_Hospital",
                table: "Courses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Doctor_LastName",
                table: "Courses",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Doctor_Specialization",
                table: "Courses",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Doctor_isDeleted",
                table: "Courses",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "ID", "Date", "GroupID", "GroupsSetupID", "Name", "Doctor_Code", "Doctor_FirstName", "Doctor_Hospital", "Doctor_LastName", "Doctor_Specialization", "Doctor_isDeleted" },
                values: new object[] { 1, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, "Internal Medicine", "IM1", "Ramez", "NNU", "Rabi", "Internal Medicine", false });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "ZajelID",
                keyValue: 11317076,
                column: "Gender",
                value: "M");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "ZajelID",
                keyValue: 11417076,
                column: "Gender",
                value: "F");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "ZajelID",
                keyValue: 11517076,
                column: "Gender",
                value: "M");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_GroupsSetupID",
                table: "Courses",
                column: "GroupsSetupID");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Groups_GroupsSetupID",
                table: "Courses",
                column: "GroupsSetupID",
                principalTable: "Groups",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Groups_GroupsSetupID",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_GroupsSetupID",
                table: "Courses");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "GroupsSetupID",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Doctor_Code",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Doctor_FirstName",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Doctor_Hospital",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Doctor_LastName",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Doctor_Specialization",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Doctor_isDeleted",
                table: "Courses");

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Code = table.Column<string>(nullable: false),
                    CourseID = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 30, nullable: true),
                    Hospital = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(maxLength: 30, nullable: true),
                    Specialization = table.Column<string>(nullable: true),
                    isDeleted = table.Column<bool>(nullable: false)
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

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "ZajelID",
                keyValue: 11317076,
                column: "Gender",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "ZajelID",
                keyValue: 11417076,
                column: "Gender",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "ZajelID",
                keyValue: 11517076,
                column: "Gender",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_GroupID",
                table: "Courses",
                column: "GroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_CourseID",
                table: "Doctors",
                column: "CourseID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Groups_GroupID",
                table: "Courses",
                column: "GroupID",
                principalTable: "Groups",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
