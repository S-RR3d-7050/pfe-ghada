using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations.SqlServerMigrations
{
    public partial class ReleaseFinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MédecinPrescripteurId",
                table: "Admissions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Admissions_MédecinPrescripteurId",
                table: "Admissions",
                column: "MédecinPrescripteurId");

            migrationBuilder.AddForeignKey(
                name: "FK_Admissions_Users_MédecinPrescripteurId",
                table: "Admissions",
                column: "MédecinPrescripteurId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admissions_Users_MédecinPrescripteurId",
                table: "Admissions");

            migrationBuilder.DropIndex(
                name: "IX_Admissions_MédecinPrescripteurId",
                table: "Admissions");

            migrationBuilder.DropColumn(
                name: "MédecinPrescripteurId",
                table: "Admissions");
        }
    }
}
