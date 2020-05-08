using Microsoft.EntityFrameworkCore.Migrations;

namespace BluegrassPetCare.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SpeciesCreateViewModelSpeciesId",
                table: "Species",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Species",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpeciesCreateViewModelSpeciesId",
                table: "Pet",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SpeciesCreateViewModel",
                columns: table => new
                {
                    SpeciesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(maxLength: 55, nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    PetId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeciesCreateViewModel", x => x.SpeciesId);
                    table.ForeignKey(
                        name: "FK_SpeciesCreateViewModel_Pet_PetId",
                        column: x => x.PetId,
                        principalTable: "Pet",
                        principalColumn: "PetId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpeciesCreateViewModel_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "74583607-82f5-49cf-b14d-146e5dcc89fa", "AQAAAAEAACcQAAAAEJUjAMZaje8bBDSTPJU2o1ggkyFXtdxMn7QFv7LISFKciZGjSOSQMAwEAKPfNbsTkg==" });

            migrationBuilder.CreateIndex(
                name: "IX_Species_SpeciesCreateViewModelSpeciesId",
                table: "Species",
                column: "SpeciesCreateViewModelSpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_Pet_SpeciesCreateViewModelSpeciesId",
                table: "Pet",
                column: "SpeciesCreateViewModelSpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_SpeciesCreateViewModel_PetId",
                table: "SpeciesCreateViewModel",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_SpeciesCreateViewModel_UserId",
                table: "SpeciesCreateViewModel",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pet_SpeciesCreateViewModel_SpeciesCreateViewModelSpeciesId",
                table: "Pet",
                column: "SpeciesCreateViewModelSpeciesId",
                principalTable: "SpeciesCreateViewModel",
                principalColumn: "SpeciesId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Species_SpeciesCreateViewModel_SpeciesCreateViewModelSpeciesId",
                table: "Species",
                column: "SpeciesCreateViewModelSpeciesId",
                principalTable: "SpeciesCreateViewModel",
                principalColumn: "SpeciesId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pet_SpeciesCreateViewModel_SpeciesCreateViewModelSpeciesId",
                table: "Pet");

            migrationBuilder.DropForeignKey(
                name: "FK_Species_SpeciesCreateViewModel_SpeciesCreateViewModelSpeciesId",
                table: "Species");

            migrationBuilder.DropTable(
                name: "SpeciesCreateViewModel");

            migrationBuilder.DropIndex(
                name: "IX_Species_SpeciesCreateViewModelSpeciesId",
                table: "Species");

            migrationBuilder.DropIndex(
                name: "IX_Pet_SpeciesCreateViewModelSpeciesId",
                table: "Pet");

            migrationBuilder.DropColumn(
                name: "SpeciesCreateViewModelSpeciesId",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "SpeciesCreateViewModelSpeciesId",
                table: "Pet");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a7bc2615-46d8-4382-986e-d8d41103781c", "AQAAAAEAACcQAAAAENznur1Eb5F8NztE8pnwCGuxhkwVmWbxlVC0T2JzRS539Sjr2SpH6gWmLmBgKpSolw==" });
        }
    }
}
