using Microsoft.EntityFrameworkCore.Migrations;

namespace BluegrassPetCare.Migrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "SpeciesCreateViewModel");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Sex");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "SpeciesCreateViewModel",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpeciesType",
                table: "Species",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SexType",
                table: "Sex",
                maxLength: 255,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5fdd8e35-264d-4a79-b0f1-39037aecaeea", "AQAAAAEAACcQAAAAECaFI/kTjmrRSV94UVZ9H5lm4yDuFKoxkIy1xEZSgdxz0U+L4xw/kKmf9NfnbE2Xnw==" });

            migrationBuilder.UpdateData(
                table: "Sex",
                keyColumn: "SexId",
                keyValue: 1,
                column: "SexType",
                value: "Male");

            migrationBuilder.UpdateData(
                table: "Sex",
                keyColumn: "SexId",
                keyValue: 2,
                column: "SexType",
                value: "Female");

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "SpeciesId",
                keyValue: 1,
                column: "SpeciesType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "SpeciesId",
                keyValue: 2,
                column: "SpeciesType",
                value: "Cat");

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "SpeciesId",
                keyValue: 3,
                column: "SpeciesType",
                value: "Wolf");

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "SpeciesId",
                keyValue: 4,
                column: "SpeciesType",
                value: "Human");

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "SpeciesId",
                keyValue: 5,
                column: "SpeciesType",
                value: "Bald Eagle");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "SpeciesCreateViewModel");

            migrationBuilder.DropColumn(
                name: "SpeciesType",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "SexType",
                table: "Sex");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "SpeciesCreateViewModel",
                type: "nvarchar(55)",
                maxLength: 55,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Species",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Sex",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "74583607-82f5-49cf-b14d-146e5dcc89fa", "AQAAAAEAACcQAAAAEJUjAMZaje8bBDSTPJU2o1ggkyFXtdxMn7QFv7LISFKciZGjSOSQMAwEAKPfNbsTkg==" });

            migrationBuilder.UpdateData(
                table: "Sex",
                keyColumn: "SexId",
                keyValue: 1,
                column: "Type",
                value: "Male");

            migrationBuilder.UpdateData(
                table: "Sex",
                keyColumn: "SexId",
                keyValue: 2,
                column: "Type",
                value: "Female");

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "SpeciesId",
                keyValue: 1,
                column: "Type",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "SpeciesId",
                keyValue: 2,
                column: "Type",
                value: "Cat");

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "SpeciesId",
                keyValue: 3,
                column: "Type",
                value: "Wolf");

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "SpeciesId",
                keyValue: 4,
                column: "Type",
                value: "Human");

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "SpeciesId",
                keyValue: 5,
                column: "Type",
                value: "Bald Eagle");
        }
    }
}
