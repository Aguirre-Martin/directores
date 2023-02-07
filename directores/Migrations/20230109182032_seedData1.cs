using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace directores.Migrations
{
    /// <inheritdoc />
    public partial class seedData1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Directores",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Maffia movies", "Martin Scorsese" },
                    { 2, "Adaptation movies", "Stanley Kubrick" },
                    { 3, "Suspense movies", "Alfred Hitchcock" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "DirectorId", "Location", "Name", "Year" },
                values: new object[,]
                {
                    { 1, "Maffia Code's movie", 1, "Pittsburgh", "Goodfellas", 1990 },
                    { 2, "Maffia and gambling movie", 1, "Las vegas", "Casino", 1995 },
                    { 3, "Distopic movie", 2, "United Kingdom", "A clockwork orange", 1971 },
                    { 4, "Psicological horror movie", 2, "Overlock Hotel", "The shining", 1980 },
                    { 5, "Mental ilness movie, split personality", 3, "California", "Psycho", 1960 },
                    { 6, "Spy movie", 3, "New York", "Notorious", 1946 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Directores",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Directores",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Directores",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
