using Microsoft.EntityFrameworkCore.Migrations;

namespace BluegrassPetCare.Migrations
{
    public partial class FixnNotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a50e2a4a-05a5-46ce-ac60-c50ae6e524df", "AQAAAAEAACcQAAAAEAaQy1uGCpRFygiHj6BBr+o7uWT4Eu66xMJtw0DzOXsPBuH83L5tnUygwbbdjl3zEA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c07bb910-5db8-4c13-88be-6e67128c478d", "AQAAAAEAACcQAAAAEEV+x4u4WXLsvcULS+T4z8tRyWB/8N/8owEDBBAAdl/gcozTPNH+nHpZVPp5UPtUWQ==" });
        }
    }
}
