using Microsoft.EntityFrameworkCore.Migrations;

namespace BluegrassPetCare.Migrations
{
    public partial class New : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsVetrinarian",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<bool>(
                name: "IsVeterinarian",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c07bb910-5db8-4c13-88be-6e67128c478d", "AQAAAAEAACcQAAAAEEV+x4u4WXLsvcULS+T4z8tRyWB/8N/8owEDBBAAdl/gcozTPNH+nHpZVPp5UPtUWQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsVeterinarian",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<bool>(
                name: "IsVetrinarian",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2bda2135-a3ad-4109-ac59-783dd97cee61", "AQAAAAEAACcQAAAAEN+nKB5MqxWdTqEZEPdj6T63Yl0E9uP+xz/We/NkW7alJStllNLG8z6tTZeSkh6/1g==" });
        }
    }
}
