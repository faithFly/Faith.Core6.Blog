using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Faith.DbMigrator.Migrations
{
    public partial class addtag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserTag",
                table: "T_Users",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserTag",
                table: "T_Users");
        }
    }
}
