using Microsoft.EntityFrameworkCore.Migrations;

namespace CommandsService.Persistence.EntityFramework.Migrations
{
    public partial class Alter_Platforms_Add_Nonclustered_Indexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Platforms_IsDeleted",
                table: "Platforms",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Platforms_Name_IsDeleted",
                table: "Platforms",
                columns: new[] { "Name", "IsDeleted" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Platforms_IsDeleted",
                table: "Platforms");

            migrationBuilder.DropIndex(
                name: "IX_Platforms_Name_IsDeleted",
                table: "Platforms");
        }
    }
}
