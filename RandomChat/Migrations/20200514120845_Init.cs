using Microsoft.EntityFrameworkCore.Migrations;

namespace RandomChat.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.Email);
                    table.CheckConstraint("CH_Login_PasswordHash", "len(PasswordHash) = 64");
                });

            migrationBuilder.CreateTable(
                name: "Verifications",
                columns: table => new
                {
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Code = table.Column<string>(maxLength: 6, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verifications", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Appusers",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gender = table.Column<string>(nullable: true),
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

            migrationBuilder.CreateIndex(
                name: "IX_Appusers_Email",
                table: "Appusers",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appusers");

            migrationBuilder.DropTable(
                name: "Verifications");

            migrationBuilder.DropTable(
                name: "Logins");
        }
    }
}
