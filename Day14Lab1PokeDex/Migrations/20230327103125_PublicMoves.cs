using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Day14Lab1PokeDex.Migrations
{
    /// <inheritdoc />
    public partial class PublicMoves : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PokemonID",
                table: "Moves",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Moves_PokemonID",
                table: "Moves",
                column: "PokemonID");

            migrationBuilder.AddForeignKey(
                name: "FK_Moves_Pokemons_PokemonID",
                table: "Moves",
                column: "PokemonID",
                principalTable: "Pokemons",
                principalColumn: "PokemonID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Moves_Pokemons_PokemonID",
                table: "Moves");

            migrationBuilder.DropIndex(
                name: "IX_Moves_PokemonID",
                table: "Moves");

            migrationBuilder.DropColumn(
                name: "PokemonID",
                table: "Moves");
        }
    }
}
