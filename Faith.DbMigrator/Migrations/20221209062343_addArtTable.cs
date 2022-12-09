using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Faith.DbMigrator.Migrations
{
    public partial class addArtTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_Articles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CategorysId = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ArticleTitle = table.Column<string>(type: "varchar(200)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Md5ArticleFileUrl = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreateBy = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UpdateTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdateBy = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Articles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_Articles");
        }
    }
}
