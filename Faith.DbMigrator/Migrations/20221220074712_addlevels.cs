using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Faith.DbMigrator.Migrations
{
    public partial class addlevels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "T_Categorize",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "T_Categorize");
        }
    }
}
