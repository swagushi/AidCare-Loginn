using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AidCare_Loginn.Migrations
{
    public partial class viewaddedformember : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "member",
                columns: table => new
                {
                    memberID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_member", x => x.memberID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "member");
        }
    }
}
