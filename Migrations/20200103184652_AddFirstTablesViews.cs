using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace EV.Migrations
{
    public partial class AddFirstTablesViews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EvTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EvTypeAbbr = table.Column<string>(nullable: false),
                    EvTypeShortDescription = table.Column<string>(nullable: true),
                    EvTypeLongDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EVehicles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EvTypeId = table.Column<int>(nullable: false),
                    Manufacturer = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    BatteryCapacity = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EVehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EVehicles_EvTypes_EvTypeId",
                        column: x => x.EvTypeId,
                        principalTable: "EvTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EVehicles_EvTypeId",
                table: "EVehicles",
                column: "EvTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EVehicles");

            migrationBuilder.DropTable(
                name: "EvTypes");
        }
    }
}
