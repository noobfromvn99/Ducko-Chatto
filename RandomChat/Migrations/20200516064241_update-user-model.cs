using Microsoft.EntityFrameworkCore.Migrations;

namespace RandomChat.Migrations
{
    public partial class updateusermodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(maxLength: 64, nullable: false),
                    Activate = table.Column<bool>(nullable: false),
                    Code = table.Column<string>(maxLength: 6, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.Email);
                    table.CheckConstraint("CH_Login_PasswordHash", "len(PasswordHash) = 64");
                });

            migrationBuilder.CreateTable(
                name: "Appusers",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appusers", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Appusers_Logins_Email",
                        column: x => x.Email,
                        principalTable: "Logins",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    TopicId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TopicName = table.Column<string>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.TopicId);
                    table.ForeignKey(
                        name: "FK_Topics_Appusers_UserId",
                        column: x => x.UserId,
                        principalTable: "Appusers",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appusers_Email",
                table: "Appusers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Topics_UserId",
                table: "Topics",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "Appusers");

            migrationBuilder.DropTable(
                name: "Logins");
        }
    }
}
