using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DEWalksAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedingdataforDifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("54466f17-02af-48e7-8ed3-5a4a8bfacf6f"), "Easy" },
                    { new Guid("ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c"), "Medium" },
                    { new Guid("f808ddcd-b5e5-4d80-b732-1ca523e48434"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("14ceba71-4b51-4777-9b17-46602cf66153"), "HH", "Hamburg", "https://upload.wikimedia.org/wikipedia/commons/f/f3/Speicherstadt%2C_Hamburg.jpg" },
                    { new Guid("6884f7d7-ad1f-4101-8df3-7a6fa7387d81"), "BE", "Berlin", "https://upload.wikimedia.org/wikipedia/commons/a/a6/Berliner_Fernsehturm_abends.jpg" },
                    { new Guid("906cb139-415a-4bbb-a174-1a1faf9fb1f6"), "SN", "Sachsen", "https://upload.wikimedia.org/wikipedia/commons/3/3b/Bastei_2006.jpg" },
                    { new Guid("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"), "NW", "Nordrhein-Westfalen", "https://upload.wikimedia.org/wikipedia/commons/2/2b/K%C3%B6lner_Dom_und_Hohenzollernbr%C3%BCcke_abends.jpg" },
                    { new Guid("f077a22e-4248-4bf6-b564-c7cf4e250263"), "BW", "Baden-Württemberg", "https://upload.wikimedia.org/wikipedia/commons/8/83/Heidelberg_Schloss_und_Alte_Br%C3%BCcke.jpg" },
                    { new Guid("f7248fc3-2585-4efb-8d1d-1c555f4087f6"), "BY", "Bayern", "https://upload.wikimedia.org/wikipedia/commons/8/84/Neuschwanstein_Castle_LOC_print.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("54466f17-02af-48e7-8ed3-5a4a8bfacf6f"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("f808ddcd-b5e5-4d80-b732-1ca523e48434"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("14ceba71-4b51-4777-9b17-46602cf66153"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("6884f7d7-ad1f-4101-8df3-7a6fa7387d81"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("906cb139-415a-4bbb-a174-1a1faf9fb1f6"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f077a22e-4248-4bf6-b564-c7cf4e250263"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f7248fc3-2585-4efb-8d1d-1c555f4087f6"));
        }
    }
}
