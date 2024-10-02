using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class GestionPagosv5ApiKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApiKey",
                schema: "sch_gespago",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    app = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false),
                    fechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaExpiracion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiKey", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApiKey_app",
                schema: "sch_gespago",
                table: "ApiKey",
                column: "app",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApiKey_id",
                schema: "sch_gespago",
                table: "ApiKey",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApiKey",
                schema: "sch_gespago");
        }
    }
}
