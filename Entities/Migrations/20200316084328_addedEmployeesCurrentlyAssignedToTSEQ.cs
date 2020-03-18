using Microsoft.EntityFrameworkCore.Migrations;

namespace GCSClasses.Migrations
{
    public partial class addedEmployeesCurrentlyAssignedToTSEQ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeesCurrentlyAssigned",
                table: "Task Skill Employees Quantity",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeesCurrentlyAssigned",
                table: "Task Skill Employees Quantity");
        }
    }
}
