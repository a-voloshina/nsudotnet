using Microsoft.EntityFrameworkCore.Migrations;

namespace EffectiveWorker.Migrations
{
    public partial class AddWorkerSeniority : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Seniority",
                table: "Workers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Seniority",
                table: "Workers");
        }
    }
}