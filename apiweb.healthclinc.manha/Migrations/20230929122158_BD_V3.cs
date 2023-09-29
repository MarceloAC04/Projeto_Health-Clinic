using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiweb.healthclinc.manha.Migrations
{
    /// <inheritdoc />
    public partial class BD_V3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Exibe",
                table: "Comentario",
                type: "BIT",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Exibe",
                table: "Comentario");
        }
    }
}
