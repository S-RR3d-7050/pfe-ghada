using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations.SqlServerMigrations
{
    public partial class Release02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adresse",
                table: "Admissions");

            migrationBuilder.DropColumn(
                name: "DateNaissance",
                table: "Admissions");

            migrationBuilder.DropColumn(
                name: "Identifiant",
                table: "Admissions");

            migrationBuilder.DropColumn(
                name: "Nationnalité",
                table: "Admissions");

            migrationBuilder.DropColumn(
                name: "Nom",
                table: "Admissions");

            migrationBuilder.DropColumn(
                name: "NumCIN",
                table: "Admissions");

            migrationBuilder.DropColumn(
                name: "Prenom",
                table: "Admissions");

            migrationBuilder.DropColumn(
                name: "Telephone",
                table: "Admissions");

            migrationBuilder.AddColumn<string>(
                name: "Lieu",
                table: "DossierPatients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TypPCE",
                table: "DossierPatients",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lieu",
                table: "DossierPatients");

            migrationBuilder.DropColumn(
                name: "TypPCE",
                table: "DossierPatients");

            migrationBuilder.AddColumn<string>(
                name: "Adresse",
                table: "Admissions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateNaissance",
                table: "Admissions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Identifiant",
                table: "Admissions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Nationnalité",
                table: "Admissions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nom",
                table: "Admissions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumCIN",
                table: "Admissions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Prenom",
                table: "Admissions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telephone",
                table: "Admissions",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
