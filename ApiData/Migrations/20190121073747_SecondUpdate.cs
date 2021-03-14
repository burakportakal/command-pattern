using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiData.Migrations
{
    public partial class SecondUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Event",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationID",
                table: "Event",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OnlineUrl",
                table: "Event",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    LocationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.LocationID);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    SessionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Presenter = table.Column<string>(nullable: true),
                    Duration = table.Column<int>(nullable: false),
                    Level = table.Column<string>(nullable: true),
                    Abstract = table.Column<string>(nullable: true),
                    EventID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.SessionID);
                    table.ForeignKey(
                        name: "FK_Sessions_Event_EventID",
                        column: x => x.EventID,
                        principalTable: "Event",
                        principalColumn: "EventID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Event_LocationID",
                table: "Event",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_EventID",
                table: "Sessions",
                column: "EventID");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Location_LocationID",
                table: "Event",
                column: "LocationID",
                principalTable: "Location",
                principalColumn: "LocationID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Location_LocationID",
                table: "Event");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Event_LocationID",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "LocationID",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "OnlineUrl",
                table: "Event");
        }
    }
}
