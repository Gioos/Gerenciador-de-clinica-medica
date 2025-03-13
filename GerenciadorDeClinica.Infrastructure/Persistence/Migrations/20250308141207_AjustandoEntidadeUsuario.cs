using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorDeClinica.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AjustandoEntidadeUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Usuarios");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
