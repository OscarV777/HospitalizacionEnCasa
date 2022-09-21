using Microsoft.EntityFrameworkCore.Migrations;

namespace MantenimientoComputadores.Persistencia.Migrations
{
    public partial class NumeroDocumento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NumeroDocumento",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumeroDocumento",
                table: "Personas");
        }
    }
}
