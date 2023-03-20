using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPiKiller.Migrations
{
    /// <inheritdoc />
    public partial class initialDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Killers",
                columns: table => new
                {
                    KillerID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    KillerName = table.Column<string>(type: "TEXT", nullable: false),
                    KillerDescription = table.Column<string>(type: "TEXT", nullable: false),
                    KillerKilled = table.Column<int>(type: "INTEGER", nullable: false),
                    IsInJail = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Killers", x => x.KillerID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Killers");
        }
    }
}
