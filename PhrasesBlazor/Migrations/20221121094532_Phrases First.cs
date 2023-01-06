using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhrasesBlazor.Migrations
{
    /// <inheritdoc />
    public partial class PhrasesFirst : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Phrases",
                columns: table => new
                {
                    PhraseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Element = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phrase = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationID = table.Column<int>(type: "int", nullable: false),
                    PageID = table.Column<int>(type: "int", nullable: true),
                    Culture = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    OrginalPhrase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhraseDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phrases", x => x.PhraseID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Phrases");
        }
    }
}
