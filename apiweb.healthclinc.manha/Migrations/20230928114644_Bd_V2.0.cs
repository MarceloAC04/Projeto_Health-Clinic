using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiweb.healthclinc.manha.Migrations
{
    /// <inheritdoc />
    public partial class Bd_V20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medico_TiposEspecialidade_IdEspecialidade",
                table: "Medico");

            migrationBuilder.RenameColumn(
                name: "IdEspecialidade",
                table: "Medico",
                newName: "IdTipoEspecialidade");

            migrationBuilder.RenameIndex(
                name: "IX_Medico_IdEspecialidade",
                table: "Medico",
                newName: "IX_Medico_IdTipoEspecialidade");

            migrationBuilder.AddForeignKey(
                name: "FK_Medico_TiposEspecialidade_IdTipoEspecialidade",
                table: "Medico",
                column: "IdTipoEspecialidade",
                principalTable: "TiposEspecialidade",
                principalColumn: "IdTipoEspecialidade",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medico_TiposEspecialidade_IdTipoEspecialidade",
                table: "Medico");

            migrationBuilder.RenameColumn(
                name: "IdTipoEspecialidade",
                table: "Medico",
                newName: "IdEspecialidade");

            migrationBuilder.RenameIndex(
                name: "IX_Medico_IdTipoEspecialidade",
                table: "Medico",
                newName: "IX_Medico_IdEspecialidade");

            migrationBuilder.AddForeignKey(
                name: "FK_Medico_TiposEspecialidade_IdEspecialidade",
                table: "Medico",
                column: "IdEspecialidade",
                principalTable: "TiposEspecialidade",
                principalColumn: "IdTipoEspecialidade",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
