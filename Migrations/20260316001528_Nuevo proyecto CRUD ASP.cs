using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUDASP.Migrations
{
    /// <inheritdoc />
    public partial class NuevoproyectoCRUDASP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "empleado",
                columns: table => new
                {
                    Cedula = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NombreCompleto = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    correo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaContrato = table.Column<DateOnly>(type: "date", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false),
                    administrador = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empleado", x => x.Cedula);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "empleado");
        }
    }
}
