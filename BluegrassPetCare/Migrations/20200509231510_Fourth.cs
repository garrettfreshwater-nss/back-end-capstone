using Microsoft.EntityFrameworkCore.Migrations;

namespace BluegrassPetCare.Migrations
{
    public partial class Fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "SpeciesCreateViewModel");

            migrationBuilder.AddColumn<string>(
                name: "SpeciesType",
                table: "SpeciesCreateViewModel",
                maxLength: 255,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fb8714a3-8de5-42e1-929f-1bcf00406960", "AQAAAAEAACcQAAAAEKKM1jofsl9FMi4OaUKUwEgFY753O0LCJvErgAGQsqBqy1xNASblQhiZFAr5/8vBFg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpeciesType",
                table: "SpeciesCreateViewModel");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "SpeciesCreateViewModel",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5fdd8e35-264d-4a79-b0f1-39037aecaeea", "AQAAAAEAACcQAAAAECaFI/kTjmrRSV94UVZ9H5lm4yDuFKoxkIy1xEZSgdxz0U+L4xw/kKmf9NfnbE2Xnw==" });
        }
    }
}
