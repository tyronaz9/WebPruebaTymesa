using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebPruebaTymesa.Data.Migrations
{
    public partial class Movimientos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tipos",
                columns: table => new
                {
                    TiposID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Sigla = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Signo = table.Column<int>(type: "int", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipos", x => x.TiposID);
                });

            migrationBuilder.CreateTable(
                name: "Movimientos",
                columns: table => new
                {
                    MovimientosID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CuentasID = table.Column<int>(type: "int", nullable: false),
                    TiposID = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimientos", x => x.MovimientosID);
                    table.ForeignKey(
                        name: "FK_Movimientos_Cuentas_CuentasID",
                        column: x => x.CuentasID,
                        principalTable: "Cuentas",
                        principalColumn: "CuentasID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movimientos_Tipos_TiposID",
                        column: x => x.TiposID,
                        principalTable: "Tipos",
                        principalColumn: "TiposID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cuentas_Numero",
                table: "Cuentas",
                column: "Numero",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_UserName",
                table: "Clientes",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_CuentasID",
                table: "Movimientos",
                column: "CuentasID");

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_TiposID",
                table: "Movimientos",
                column: "TiposID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movimientos");

            migrationBuilder.DropTable(
                name: "Tipos");

            migrationBuilder.DropIndex(
                name: "IX_Cuentas_Numero",
                table: "Cuentas");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_UserName",
                table: "Clientes");
        }
    }
}
