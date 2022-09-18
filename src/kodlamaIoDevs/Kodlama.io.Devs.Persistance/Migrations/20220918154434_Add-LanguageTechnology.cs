using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kodlama.io.Devs.Persistance.Migrations
{
    public partial class AddLanguageTechnology : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProgrammingLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgrammingLanguages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LanguageTechnologies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgrammingLanguageId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageTechnologies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LanguageTechnologies_ProgrammingLanguages_ProgrammingLanguageId",
                        column: x => x.ProgrammingLanguageId,
                        principalTable: "ProgrammingLanguages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProgrammingLanguages",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "C#" });

            migrationBuilder.InsertData(
                table: "ProgrammingLanguages",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Java" });

            migrationBuilder.InsertData(
                table: "LanguageTechnologies",
                columns: new[] { "Id", "Name", "ProgrammingLanguageId" },
                values: new object[,]
                {
                    { 1, "ASP.NET", 1 },
                    { 2, ".NET CORE", 1 },
                    { 3, "SPRİNG", 2 },
                    { 4, "JSP", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LanguageTechnologies_ProgrammingLanguageId",
                table: "LanguageTechnologies",
                column: "ProgrammingLanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LanguageTechnologies");

            migrationBuilder.DropTable(
                name: "ProgrammingLanguages");
        }
    }
}
