using Microsoft.EntityFrameworkCore.Migrations;

namespace BluegrassPetCare.Migrations
{
    public partial class NewBreeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "SpeciesId",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8e680277-9e9f-42d7-9edb-61cec37fd326", "AQAAAAEAACcQAAAAENUzCcVARtczFLJ06ewHAsT16bE+dsgXxsqK/s/KHmbIQuygGw6Fr7zuEhixH4bwRA==" });

            migrationBuilder.InsertData(
                table: "Breed",
                columns: new[] { "BreedId", "BreedName" },
                values: new object[,]
                {
                    { 5, "Labrador Retriever" },
                    { 6, "Mut" },
                    { 7, "Terrier" },
                    { 8, "Sphinx" },
                    { 9, "Bengal" },
                    { 10, "Ragdoll" },
                    { 11, "Burmese" },
                    { 12, "Bombay" },
                    { 13, "Pug" },
                    { 14, "Golden Retriever" },
                    { 15, "Beagle" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Breed",
                keyColumn: "BreedId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Breed",
                keyColumn: "BreedId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Breed",
                keyColumn: "BreedId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Breed",
                keyColumn: "BreedId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Breed",
                keyColumn: "BreedId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Breed",
                keyColumn: "BreedId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Breed",
                keyColumn: "BreedId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Breed",
                keyColumn: "BreedId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Breed",
                keyColumn: "BreedId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Breed",
                keyColumn: "BreedId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Breed",
                keyColumn: "BreedId",
                keyValue: 15);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a50e2a4a-05a5-46ce-ac60-c50ae6e524df", "AQAAAAEAACcQAAAAEAaQy1uGCpRFygiHj6BBr+o7uWT4Eu66xMJtw0DzOXsPBuH83L5tnUygwbbdjl3zEA==" });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "SpeciesId", "SpeciesCreateViewModelSpeciesId", "SpeciesType", "UserId" },
                values: new object[] { 4, null, "Human", null });
        }
    }
}
