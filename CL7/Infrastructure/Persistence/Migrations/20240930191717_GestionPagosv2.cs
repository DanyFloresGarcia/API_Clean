using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class GestionPagosv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DocumentoPagoDetalle",
                schema: "sch_gespago",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pagoMasivoDetalleId = table.Column<int>(type: "int", nullable: false),
                    documentoPagoId = table.Column<int>(type: "int", nullable: false),
                    monto = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentoPagoDetalle", x => x.id);
                    table.ForeignKey(
                        name: "FK_DocumentoPagoDetalle_DocumentoPago_documentoPagoId",
                        column: x => x.documentoPagoId,
                        principalSchema: "sch_gespago",
                        principalTable: "DocumentoPago",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plataforma",
                schema: "sch_gespago",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    entidadBancariaId = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plataforma", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ModalidadPago",
                schema: "sch_gespago",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    plataformaId = table.Column<int>(type: "int", nullable: false),
                    version = table.Column<int>(type: "int", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false),
                    ruta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    formato = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModalidadPago", x => x.id);
                    table.ForeignKey(
                        name: "FK_ModalidadPago_Plataforma_plataformaId",
                        column: x => x.plataformaId,
                        principalSchema: "sch_gespago",
                        principalTable: "Plataforma",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentoPago_id",
                schema: "sch_gespago",
                table: "DocumentoPago",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_Auditoria_id",
                schema: "sch_gespago",
                table: "Auditoria",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentoPagoDetalle_documentoPagoId",
                schema: "sch_gespago",
                table: "DocumentoPagoDetalle",
                column: "documentoPagoId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentoPagoDetalle_id",
                schema: "sch_gespago",
                table: "DocumentoPagoDetalle",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_ModalidadPago_id",
                schema: "sch_gespago",
                table: "ModalidadPago",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_ModalidadPago_plataformaId",
                schema: "sch_gespago",
                table: "ModalidadPago",
                column: "plataformaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentoPagoDetalle",
                schema: "sch_gespago");

            migrationBuilder.DropTable(
                name: "ModalidadPago",
                schema: "sch_gespago");

            migrationBuilder.DropTable(
                name: "Plataforma",
                schema: "sch_gespago");

            migrationBuilder.DropIndex(
                name: "IX_DocumentoPago_id",
                schema: "sch_gespago",
                table: "DocumentoPago");

            migrationBuilder.DropIndex(
                name: "IX_Auditoria_id",
                schema: "sch_gespago",
                table: "Auditoria");
        }
    }
}
