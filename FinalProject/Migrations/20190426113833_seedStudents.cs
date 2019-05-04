using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Migrations
{
    public partial class seedStudents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Groups_GroupID",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_GroupID",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "GroupsSetupID",
                table: "Students",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "ID", "Code", "EndDate", "StartDate" },
                values: new object[,]
                {
                    { 2, "B", new DateTime(2019, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "C", new DateTime(2019, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "ZajelID", "Adress", "FirstName", "GDPA", "Gender", "GroupID", "GroupsSetupID", "LastName", "NumberOFHourse", "Toofel" },
                values: new object[,]
                {
                    { 11317076, "Nablus", "Khaled", 2.5, "M", 1, null, "Ismaeel", 255, true },
                    { 11417076, "Rammallah", "Lara", 3.5, "F", 2, null, "Saka", 255, true },
                    { 11517076, "Biddya", "Osama", 2.7, "M", 3, null, "Mara", 255, true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_GroupsSetupID",
                table: "Students",
                column: "GroupsSetupID");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Groups_GroupsSetupID",
                table: "Students",
                column: "GroupsSetupID",
                principalTable: "Groups",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Groups_GroupsSetupID",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_GroupsSetupID",
                table: "Students");

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "ZajelID",
                keyValue: 11317076);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "ZajelID",
                keyValue: 11417076);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "ZajelID",
                keyValue: 11517076);

            migrationBuilder.DropColumn(
                name: "GroupsSetupID",
                table: "Students");

            migrationBuilder.CreateIndex(
                name: "IX_Students_GroupID",
                table: "Students",
                column: "GroupID");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Groups_GroupID",
                table: "Students",
                column: "GroupID",
                principalTable: "Groups",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
