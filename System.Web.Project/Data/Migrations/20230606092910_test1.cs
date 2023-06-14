using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace System.Web.Project.Data.Migrations
{
    public partial class test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Events_EmployeeId",
                table: "Events",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Employees_EmployeeId",
                table: "Events",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Employees_EmployeeId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_EmployeeId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Events");
        }
    }
}
