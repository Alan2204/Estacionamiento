using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Estacionamiento.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estacionamientos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dir = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EspMax = table.Column<int>(type: "int", nullable: false),
                    Tarifa = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estacionamientos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Lugar",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    No = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lugar", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Matricula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculo", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Ingreso",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idEstacionamientos = table.Column<int>(type: "int", nullable: false),
                    idVehiculo = table.Column<int>(type: "int", nullable: false),
                    idLugar = table.Column<int>(type: "int", nullable: false),
                    HoraEntrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraSalida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Monto = table.Column<float>(type: "real", nullable: false),
                    Estacionamientosid = table.Column<int>(type: "int", nullable: true),
                    Vehiculoid = table.Column<int>(type: "int", nullable: true),
                    Lugarid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingreso", x => x.id);
                    table.ForeignKey(
                        name: "FK_Ingreso_Estacionamientos_Estacionamientosid",
                        column: x => x.Estacionamientosid,
                        principalTable: "Estacionamientos",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Ingreso_Lugar_Lugarid",
                        column: x => x.Lugarid,
                        principalTable: "Lugar",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Ingreso_Vehiculo_Vehiculoid",
                        column: x => x.Vehiculoid,
                        principalTable: "Vehiculo",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingreso_Estacionamientosid",
                table: "Ingreso",
                column: "Estacionamientosid");

            migrationBuilder.CreateIndex(
                name: "IX_Ingreso_Lugarid",
                table: "Ingreso",
                column: "Lugarid");

            migrationBuilder.CreateIndex(
                name: "IX_Ingreso_Vehiculoid",
                table: "Ingreso",
                column: "Vehiculoid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingreso");

            migrationBuilder.DropTable(
                name: "Estacionamientos");

            migrationBuilder.DropTable(
                name: "Lugar");

            migrationBuilder.DropTable(
                name: "Vehiculo");
        }
    }
}
