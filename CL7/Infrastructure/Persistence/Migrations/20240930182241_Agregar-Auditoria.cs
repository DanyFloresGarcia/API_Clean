using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AgregarAuditoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "sch_gespago");

            migrationBuilder.CreateTable(
                name: "Auditoria",
                schema: "sch_gespago",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    documentoPagoId = table.Column<int>(type: "int", nullable: false),
                    accion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fechaEnvio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    observacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    resultado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    usuarioCreadorId = table.Column<int>(type: "int", nullable: false),
                    fechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    hostCreador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    appCreador = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auditoria", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auditoria",
                schema: "sch_gespago");
        }
    }
}
