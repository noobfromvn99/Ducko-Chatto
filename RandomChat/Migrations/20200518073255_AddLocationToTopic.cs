using Microsoft.EntityFrameworkCore.Migrations;

namespace RandomChat.Migrations
{
    public partial class AddLocationToTopic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Topics",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Topics");
        }
    }
}
