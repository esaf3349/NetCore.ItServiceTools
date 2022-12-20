using Microsoft.EntityFrameworkCore.Migrations;

namespace CommandsService.Persistence.EntityFramework.Migrations
{
    public partial class Alter_Commands_Add_Nonclustered_Indexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Commands_IsDeleted",
                table: "Commands",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Commands_IsDeleted",
                table: "Commands");
        }
    }
}
