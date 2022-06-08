using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AidCare_Loginn.Migrations
{
    public partial class addednewmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "lastname",
                table: "member",
                newName: "Lastname");

            migrationBuilder.RenameColumn(
                name: "firstname",
                table: "member",
                newName: "Firstname");

            migrationBuilder.AlterColumn<string>(
                name: "Lastname",
                table: "member",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Firstname",
                table: "member",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRegistered",
                table: "member",
                type: "datetime2",
                maxLength: 50,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "donation",
                columns: table => new
                {
                    donationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonationDescription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    donationAmount = table.Column<int>(type: "int", nullable: false),
                    memberID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_donation", x => x.donationID);
                    table.ForeignKey(
                        name: "FK_donation_member_memberID",
                        column: x => x.memberID,
                        principalTable: "member",
                        principalColumn: "memberID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    EventLocation = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    EventDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.EventId);
                });

            migrationBuilder.CreateTable(
                name: "memberevent",
                columns: table => new
                {
                    membereventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    membereventName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateRegistered = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    memberId = table.Column<int>(type: "int", nullable: false),
                    eventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_memberevent", x => x.membereventId);
                    table.ForeignKey(
                        name: "FK_memberevent_Event_eventId",
                        column: x => x.eventId,
                        principalTable: "Event",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_memberevent_member_memberId",
                        column: x => x.memberId,
                        principalTable: "member",
                        principalColumn: "memberID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_donation_memberID",
                table: "donation",
                column: "memberID");

            migrationBuilder.CreateIndex(
                name: "IX_memberevent_eventId",
                table: "memberevent",
                column: "eventId");

            migrationBuilder.CreateIndex(
                name: "IX_memberevent_memberId",
                table: "memberevent",
                column: "memberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "donation");

            migrationBuilder.DropTable(
                name: "memberevent");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropColumn(
                name: "DateRegistered",
                table: "member");

            migrationBuilder.RenameColumn(
                name: "Lastname",
                table: "member",
                newName: "lastname");

            migrationBuilder.RenameColumn(
                name: "Firstname",
                table: "member",
                newName: "firstname");

            migrationBuilder.AlterColumn<string>(
                name: "lastname",
                table: "member",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "firstname",
                table: "member",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);
        }
    }
}
