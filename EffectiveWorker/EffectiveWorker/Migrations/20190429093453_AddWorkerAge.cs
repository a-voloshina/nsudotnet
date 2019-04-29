using Microsoft.EntityFrameworkCore.Migrations;

namespace EffectiveWorker.Migrations
{
    public partial class AddWorkerAge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Workers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Workers");
        }
    }
}