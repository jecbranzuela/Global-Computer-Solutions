using Microsoft.EntityFrameworkCore.Migrations;

namespace GCSClasses.Migrations
{
    public partial class longphonenumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "PhoneNumber",
                table: "Customer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PhoneNumber",
                table: "Customer",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));
        }
    }
}
