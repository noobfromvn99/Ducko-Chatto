using Microsoft.EntityFrameworkCore.Migrations;

namespace RandomChat.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgeStage",
                table: "Appusers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Appusers");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Appusers",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Appusers");

            migrationBuilder.AddColumn<int>(
                name: "AgeStage",
                table: "Appusers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Appusers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
