using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Day14Lab1PokeDex.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    PictureID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PictureName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RawData = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.PictureID);
                });

            migrationBuilder.CreateTable(
                name: "Pokemons",
                columns: table => new
                {
                    PokemonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PokemonName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PokemonWeight = table.Column<int>(type: "int", nullable: false),
                    PokemonLevel = table.Column<int>(type: "int", nullable: false),
                    PokemonXP = table.Column<int>(type: "int", nullable: false),
                    PokemonAttack = table.Column<int>(type: "int", nullable: false),
                    PokemonDefense = table.Column<int>(type: "int", nullable: false),
                    PokemonSpecialAttack = table.Column<int>(type: "int", nullable: false),
                    PokemonSpecialDefense = table.Column<int>(type: "int", nullable: false),
                    PokemonSpeeed = table.Column<int>(type: "int", nullable: false),
                    PokemonLifePoints = table.Column<int>(type: "int", nullable: false),
                    PokemonStatus = table.Column<int>(type: "int", nullable: false),
                    PictureID = table.Column<int>(type: "int", nullable: true),
                    IsMale = table.Column<bool>(type: "bit", nullable: false),
                    IsFemale = table.Column<bool>(type: "bit", nullable: false),
                    IsLegendary = table.Column<bool>(type: "bit", nullable: false),
                    IsEgg = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemons", x => x.PokemonID);
                    table.ForeignKey(
                        name: "FK_Pokemons_Pictures_PictureID",
                        column: x => x.PictureID,
                        principalTable: "Pictures",
                        principalColumn: "PictureID");
                });

            migrationBuilder.CreateTable(
                name: "Elements",
                columns: table => new
                {
                    ElementID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ElementName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PokemonID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elements", x => x.ElementID);
                    table.ForeignKey(
                        name: "FK_Elements_Pokemons_PokemonID",
                        column: x => x.PokemonID,
                        principalTable: "Pokemons",
                        principalColumn: "PokemonID");
                });

            migrationBuilder.CreateTable(
                name: "ElementsSensibilities",
                columns: table => new
                {
                    ElementSensibilityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ElementId = table.Column<int>(type: "int", nullable: false),
                    ElementSensibilityPerCent = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementsSensibilities", x => x.ElementSensibilityID);
                    table.ForeignKey(
                        name: "FK_ElementsSensibilities_Elements_ElementId",
                        column: x => x.ElementId,
                        principalTable: "Elements",
                        principalColumn: "ElementID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Moves",
                columns: table => new
                {
                    MoveID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MoveClass = table.Column<int>(type: "int", nullable: false),
                    MoveName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAttack = table.Column<bool>(type: "bit", nullable: false),
                    MoveHitPoints = table.Column<int>(type: "int", nullable: false),
                    MoveSpeedUp = table.Column<int>(type: "int", nullable: false),
                    MoveAttackUp = table.Column<int>(type: "int", nullable: false),
                    MoveDefenseUp = table.Column<int>(type: "int", nullable: false),
                    MoveLifePointsUp = table.Column<int>(type: "int", nullable: false),
                    IsPriority = table.Column<bool>(type: "bit", nullable: false),
                    MovePrecision = table.Column<int>(type: "int", nullable: false),
                    MoveMaxRepeat = table.Column<int>(type: "int", nullable: false),
                    IsElementary = table.Column<bool>(type: "bit", nullable: false),
                    ElementID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moves", x => x.MoveID);
                    table.ForeignKey(
                        name: "FK_Moves_Elements_ElementID",
                        column: x => x.ElementID,
                        principalTable: "Elements",
                        principalColumn: "ElementID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Elements_PokemonID",
                table: "Elements",
                column: "PokemonID");

            migrationBuilder.CreateIndex(
                name: "IX_ElementsSensibilities_ElementId",
                table: "ElementsSensibilities",
                column: "ElementId");

            migrationBuilder.CreateIndex(
                name: "IX_Moves_ElementID",
                table: "Moves",
                column: "ElementID");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_PictureID",
                table: "Pokemons",
                column: "PictureID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElementsSensibilities");

            migrationBuilder.DropTable(
                name: "Moves");

            migrationBuilder.DropTable(
                name: "Elements");

            migrationBuilder.DropTable(
                name: "Pokemons");

            migrationBuilder.DropTable(
                name: "Pictures");
        }
    }
}
