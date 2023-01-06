using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhrasesBlazor.Migrations
{
    /// <inheritdoc />
    public partial class MeraModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    ApplicationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.ApplicationID);
                });

            migrationBuilder.CreateTable(
                name: "Cultures",
                columns: table => new
                {
                    CultureID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Culture = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    created = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cultures", x => x.CultureID);
                });

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PageName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ApplicationID = table.Column<int>(type: "int", nullable: false),
                    created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "Cultures");

            migrationBuilder.DropTable(
                name: "Pages");
        }
    }
}
