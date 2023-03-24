using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Day13Lab2.Migrations
{
    /// <inheritdoc />
    public partial class initdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Zones",
                columns: table => new
                {
                    ZoneID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    TargetTemperarure = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zones", x => x.ZoneID);
                });

            migrationBuilder.CreateTable(
                name: "Temperatures",
                columns: table => new
                {
                    TemperatureID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TemperatureDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TemperatureValue = table.Column<float>(type: "REAL", nullable: false),
                    ZoneId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temperatures", x => x.TemperatureID);
                    table.ForeignKey(
                        name: "FK_Temperatures_Zones_ZoneId",
                        column: x => x.ZoneId,
                        principalTable: "Zones",
                        principalColumn: "ZoneID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Temperatures_ZoneId",
                table: "Temperatures",
                column: "ZoneId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Temperatures");

            migrationBuilder.DropTable(
                name: "Zones");
        }
    }
}
