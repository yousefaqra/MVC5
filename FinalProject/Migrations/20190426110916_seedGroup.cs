using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Migrations
{
    public partial class seedGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Groups_GroupCode",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Groups_GroupCode",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_GroupCode",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Groups",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Courses_GroupCode",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "GroupCode",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GroupCode",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "GroupID",
                table: "Students",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Groups",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Groups",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "GroupID",
                table: "Courses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Groups",
                table: "Groups",
                column: "ID");

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "ID", "Code", "EndDate", "StartDate" },
                values: new object[] { 1, "A", new DateTime(2019, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Students_GroupID",
                table: "Students",
                column: "GroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_GroupID",
                table: "Courses",
                column: "GroupID");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Groups_GroupID",
                table: "Courses",
                column: "GroupID",
                principalTable: "Groups",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Groups_GroupID",
                table: "Students",
                column: "GroupID",
                principalTable: "Groups",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Groups_GroupID",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Groups_GroupID",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_GroupID",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Groups",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Courses_GroupID",
                table: "Courses");

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "GroupID",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "GroupID",
                table: "Courses");

            migrationBuilder.AddColumn<string>(
                name: "GroupCode",
                table: "Students",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Groups",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GroupCode",
                table: "Courses",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Groups",
                table: "Groups",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_Students_GroupCode",
                table: "Students",
                column: "GroupCode");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_GroupCode",
                table: "Courses",
                column: "GroupCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Groups_GroupCode",
                table: "Courses",
                column: "GroupCode",
                principalTable: "Groups",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Groups_GroupCode",
                table: "Students",
                column: "GroupCode",
                principalTable: "Groups",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
