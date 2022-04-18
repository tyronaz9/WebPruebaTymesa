using Microsoft.EntityFrameworkCore.Migrations;

namespace WebPruebaTymesa.Data.Migrations
{
    public partial class SaludAct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescripciones_Medicinas_MedicinasMedicinaID",
                table: "Prescripciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescripciones_Pacientes_PacientesPacienteID",
                table: "Prescripciones");

            migrationBuilder.DropIndex(
                name: "IX_Prescripciones_MedicinasMedicinaID",
                table: "Prescripciones");

            migrationBuilder.DropIndex(
                name: "IX_Prescripciones_PacientesPacienteID",
                table: "Prescripciones");

            migrationBuilder.DropColumn(
                name: "MedicinasMedicinaID",
                table: "Prescripciones");

            migrationBuilder.DropColumn(
                name: "PacientesPacienteID",
                table: "Prescripciones");

            migrationBuilder.RenameColumn(
                name: "PacienteID",
                table: "Prescripciones",
                newName: "PacientesID");

            migrationBuilder.RenameColumn(
                name: "MedicinaID",
                table: "Prescripciones",
                newName: "MedicinasID");

            migrationBuilder.RenameColumn(
                name: "PacienteID",
                table: "Pacientes",
                newName: "PacientesID");

            migrationBuilder.RenameColumn(
                name: "MedicinaID",
                table: "Medicinas",
                newName: "MedicinasID");

            migrationBuilder.AlterColumn<float>(
                name: "Peso",
                table: "Pacientes",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<float>(
                name: "Altura",
                table: "Pacientes",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateIndex(
                name: "IX_Prescripciones_MedicinasID",
                table: "Prescripciones",
                column: "MedicinasID");

            migrationBuilder.CreateIndex(
                name: "IX_Prescripciones_PacientesID",
                table: "Prescripciones",
                column: "PacientesID");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescripciones_Medicinas_MedicinasID",
                table: "Prescripciones",
                column: "MedicinasID",
                principalTable: "Medicinas",
                principalColumn: "MedicinasID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescripciones_Pacientes_PacientesID",
                table: "Prescripciones",
                column: "PacientesID",
                principalTable: "Pacientes",
                principalColumn: "PacientesID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescripciones_Medicinas_MedicinasID",
                table: "Prescripciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescripciones_Pacientes_PacientesID",
                table: "Prescripciones");

            migrationBuilder.DropIndex(
                name: "IX_Prescripciones_MedicinasID",
                table: "Prescripciones");

            migrationBuilder.DropIndex(
                name: "IX_Prescripciones_PacientesID",
                table: "Prescripciones");

            migrationBuilder.RenameColumn(
                name: "PacientesID",
                table: "Prescripciones",
                newName: "PacienteID");

            migrationBuilder.RenameColumn(
                name: "MedicinasID",
                table: "Prescripciones",
                newName: "MedicinaID");

            migrationBuilder.RenameColumn(
                name: "PacientesID",
                table: "Pacientes",
                newName: "PacienteID");

            migrationBuilder.RenameColumn(
                name: "MedicinasID",
                table: "Medicinas",
                newName: "MedicinaID");

            migrationBuilder.AddColumn<int>(
                name: "MedicinasMedicinaID",
                table: "Prescripciones",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PacientesPacienteID",
                table: "Prescripciones",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Peso",
                table: "Pacientes",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<decimal>(
                name: "Altura",
                table: "Pacientes",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.CreateIndex(
                name: "IX_Prescripciones_MedicinasMedicinaID",
                table: "Prescripciones",
                column: "MedicinasMedicinaID");

            migrationBuilder.CreateIndex(
                name: "IX_Prescripciones_PacientesPacienteID",
                table: "Prescripciones",
                column: "PacientesPacienteID");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescripciones_Medicinas_MedicinasMedicinaID",
                table: "Prescripciones",
                column: "MedicinasMedicinaID",
                principalTable: "Medicinas",
                principalColumn: "MedicinaID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescripciones_Pacientes_PacientesPacienteID",
                table: "Prescripciones",
                column: "PacientesPacienteID",
                principalTable: "Pacientes",
                principalColumn: "PacienteID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
