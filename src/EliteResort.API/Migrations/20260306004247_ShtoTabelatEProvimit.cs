using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EliteResort.API.Migrations
{
    /// <inheritdoc />
    public partial class ShtoTabelatEProvimit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmriPrinderit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pershkrimi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmriPrinderit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmriFemijet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Detaji = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmriPrindId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmriFemijet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmriFemijet_EmriPrinderit_EmriPrindId",
                        column: x => x.EmriPrindId,
                        principalTable: "EmriPrinderit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmriFemijet_EmriPrindId",
                table: "EmriFemijet",
                column: "EmriPrindId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmriFemijet");

            migrationBuilder.DropTable(
                name: "EmriPrinderit");
        }
    }
}
