using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorDeClinica.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SegundaMIgration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Medicos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Medicos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Medicos");
        }
    }
}
