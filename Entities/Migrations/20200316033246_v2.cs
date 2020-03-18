using Microsoft.EntityFrameworkCore.Migrations;

namespace GCSClasses.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfEmployeesNeeded",
                table: "Task Skill");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfEmployeesNeeded",
                table: "Task Skill",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
