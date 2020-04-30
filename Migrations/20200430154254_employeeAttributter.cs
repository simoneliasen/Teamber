using Microsoft.EntityFrameworkCore.Migrations;

namespace ContosoUniversity.Migrations
{
    public partial class employeeAttributter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsManager",
                table: "Employee",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "JobTitle",
                table: "Employee",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Employee",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PersonalityType",
                table: "Employee",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Employee",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsManager",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "JobTitle",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "PersonalityType",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Employee");
        }
    }
}
