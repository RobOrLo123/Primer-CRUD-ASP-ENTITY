using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUDASP.Migrations
{
    /// <inheritdoc />
    public partial class CambiodeDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "empleado");

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    Cedula = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    correo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false),
                    administrador = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.Cedula);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.CreateTable(
                name: "empleado",
                columns: table => new
                {
                    Cedula = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaContrato = table.Column<DateOnly>(type: "date", nullable: false),
                    NombreCompleto = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false),
                    administrador = table.Column<bool>(type: "bit", nullable: false),
                    correo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empleado", x => x.Cedula);
                });
        }
    }
}
