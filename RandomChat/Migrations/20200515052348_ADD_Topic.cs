using Microsoft.EntityFrameworkCore.Migrations;

namespace RandomChat.Migrations
{
    public partial class ADD_Topic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Topic",
                columns: table => new
                {
                    TopicId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TopicName = table.Column<string>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    creatorUserID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topic", x => x.TopicId);
                    table.ForeignKey(
                        name: "FK_Topic_Appusers_creatorUserID",
                        column: x => x.creatorUserID,
                        principalTable: "Appusers",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Topic_creatorUserID",
                table: "Topic",
                column: "creatorUserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Topic");
        }
    }
}
