using Microsoft.EntityFrameworkCore.Migrations;

namespace BluegrassPetCare.Migrations
{
    public partial class UserPermissions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VeterinarianEmail",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VeterinarianName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VeterinarianPhone",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2bda2135-a3ad-4109-ac59-783dd97cee61", "AQAAAAEAACcQAAAAEN+nKB5MqxWdTqEZEPdj6T63Yl0E9uP+xz/We/NkW7alJStllNLG8z6tTZeSkh6/1g==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VeterinarianEmail",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "VeterinarianName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "VeterinarianPhone",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "578570a5-e245-4c19-889f-3e3487770d33", "AQAAAAEAACcQAAAAEGAEWnawmPRmZvIlm8BqAXNH+/KIi6XuuySXRylsS5j5DHyCq3UjSFceSvfH+mTBCQ==" });
        }
    }
}
