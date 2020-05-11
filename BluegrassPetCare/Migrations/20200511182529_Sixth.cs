using Microsoft.EntityFrameworkCore.Migrations;

namespace BluegrassPetCare.Migrations
{
    public partial class Sixth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "578570a5-e245-4c19-889f-3e3487770d33", "AQAAAAEAACcQAAAAEGAEWnawmPRmZvIlm8BqAXNH+/KIi6XuuySXRylsS5j5DHyCq3UjSFceSvfH+mTBCQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fb8714a3-8de5-42e1-929f-1bcf00406960", "AQAAAAEAACcQAAAAEKKM1jofsl9FMi4OaUKUwEgFY753O0LCJvErgAGQsqBqy1xNASblQhiZFAr5/8vBFg==" });
        }
    }
}
