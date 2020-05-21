using Microsoft.EntityFrameworkCore.Migrations;

namespace BluegrassPetCare.Migrations
{
    public partial class Newww : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsVeterinarian",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b283ee53-933c-41b1-9246-0fe6630cb414", "AQAAAAEAACcQAAAAELBz+E5oQkObq0lYsRp0ket+4/UTSRdhvOdi0SeiYIskJOyktLEKh+InUk+GLqcogg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsVeterinarian",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8e680277-9e9f-42d7-9edb-61cec37fd326", "AQAAAAEAACcQAAAAENUzCcVARtczFLJ06ewHAsT16bE+dsgXxsqK/s/KHmbIQuygGw6Fr7zuEhixH4bwRA==" });
        }
    }
}
