using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AgregarAuditoriaForeneaDocumentoPago : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DocumentoPago",
                schema: "sch_gespago",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pagoMasivoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentoPago", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Auditoria_documentoPagoId",
                schema: "sch_gespago",
                table: "Auditoria",
                column: "documentoPagoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Auditoria_DocumentoPago_documentoPagoId",
                schema: "sch_gespago",
                table: "Auditoria",
                column: "documentoPagoId",
                principalSchema: "sch_gespago",
                principalTable: "DocumentoPago",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auditoria_DocumentoPago_documentoPagoId",
                schema: "sch_gespago",
                table: "Auditoria");

            migrationBuilder.DropTable(
                name: "DocumentoPago",
                schema: "sch_gespago");

            migrationBuilder.DropIndex(
                name: "IX_Auditoria_documentoPagoId",
                schema: "sch_gespago",
                table: "Auditoria");
        }
    }
}
