using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations.SqlServerMigrations
{
    public partial class MyNewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "DossierPatients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomCli = table.Column<string>(type: "TEXT", nullable: true),
                    Prenom = table.Column<string>(type: "TEXT", nullable: true),
                    NumCIN = table.Column<int>(type: "INTEGER", nullable: false),
                    Sex = table.Column<string>(type: "TEXT", nullable: true),
                    Empreinte = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Telephone = table.Column<string>(type: "TEXT", nullable: true),
                    Pays = table.Column<string>(type: "TEXT", nullable: true),
                    Prenom2 = table.Column<string>(type: "TEXT", nullable: true),
                    DatNai = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Nationnalité = table.Column<string>(type: "TEXT", nullable: true),
                    AdrChi = table.Column<string>(type: "TEXT", nullable: true),
                    AdresseLocale = table.Column<string>(type: "TEXT", nullable: true),
                    DatCIN = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PrenomPere = table.Column<string>(type: "TEXT", nullable: true),
                    Prestataire = table.Column<string>(type: "TEXT", nullable: true),
                    Traite = table.Column<string>(type: "TEXT", nullable: true),
                    Tel2 = table.Column<string>(type: "TEXT", nullable: true),
                    Gouvernorat = table.Column<string>(type: "TEXT", nullable: true),
                    CodePostale = table.Column<string>(type: "TEXT", nullable: true),
                    Délégation = table.Column<string>(type: "TEXT", nullable: true),
                    Matricule = table.Column<string>(type: "TEXT", nullable: true),
                    PatientPEC = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DossierPatients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmploiDuTemps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    KinéId = table.Column<int>(type: "INTEGER", nullable: false),
                    DateEmploi = table.Column<DateTime>(type: "TEXT", nullable: false),
                    HDébutMatinée = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    HFinMatinée = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    HDebutApMidi = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    HFinApMidi = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    HDébutSoir = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    HFinSoir = table.Column<TimeSpan>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploiDuTemps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmploiDuTemps_Users_KinéId",
                        column: x => x.KinéId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Admissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    dossierPatientId = table.Column<int>(type: "INTEGER", nullable: false),
                    Identifiant = table.Column<int>(type: "INTEGER", nullable: false),
                    Nom = table.Column<string>(type: "TEXT", nullable: true),
                    Prenom = table.Column<string>(type: "TEXT", nullable: true),
                    DateNaissance = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Nationnalité = table.Column<string>(type: "TEXT", nullable: true),
                    Type = table.Column<string>(type: "TEXT", nullable: true),
                    Adresse = table.Column<string>(type: "TEXT", nullable: true),
                    Telephone = table.Column<string>(type: "TEXT", nullable: true),
                    NumCIN = table.Column<int>(type: "INTEGER", nullable: false),
                    Société = table.Column<string>(type: "TEXT", nullable: true),
                    Matricule = table.Column<string>(type: "TEXT", nullable: true),
                    DatePEC = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NumPEC = table.Column<int>(type: "INTEGER", nullable: false),
                    MédecinTraitantId = table.Column<int>(type: "INTEGER", nullable: false),
                    MédecinCorrespondantId = table.Column<int>(type: "INTEGER", nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: true),
                    Désignation = table.Column<string>(type: "TEXT", nullable: true),
                    SJour = table.Column<string>(type: "TEXT", nullable: true),
                    Jour = table.Column<string>(type: "TEXT", nullable: true),
                    Période = table.Column<string>(type: "TEXT", nullable: true),
                    Chambre = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admissions_DossierPatients_dossierPatientId",
                        column: x => x.dossierPatientId,
                        principalTable: "DossierPatients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Admissions_Users_MédecinCorrespondantId",
                        column: x => x.MédecinCorrespondantId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Admissions_Users_MédecinTraitantId",
                        column: x => x.MédecinTraitantId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RendezVous",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    heureRDV = table.Column<int>(type: "INTEGER", nullable: false),
                    dateRDV = table.Column<DateTime>(type: "TEXT", nullable: false),
                    dossierPatientId = table.Column<int>(type: "INTEGER", nullable: false),
                    Code = table.Column<int>(type: "INTEGER", nullable: false),
                    Désignation = table.Column<string>(type: "TEXT", nullable: true),
                    MédecinTraitantId = table.Column<int>(type: "INTEGER", nullable: false),
                    MédecinCorrespondantId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RendezVous", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RendezVous_DossierPatients_dossierPatientId",
                        column: x => x.dossierPatientId,
                        principalTable: "DossierPatients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RendezVous_Users_MédecinCorrespondantId",
                        column: x => x.MédecinCorrespondantId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RendezVous_Users_MédecinTraitantId",
                        column: x => x.MédecinTraitantId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admissions_dossierPatientId",
                table: "Admissions",
                column: "dossierPatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Admissions_MédecinCorrespondantId",
                table: "Admissions",
                column: "MédecinCorrespondantId");

            migrationBuilder.CreateIndex(
                name: "IX_Admissions_MédecinTraitantId",
                table: "Admissions",
                column: "MédecinTraitantId");

            migrationBuilder.CreateIndex(
                name: "IX_EmploiDuTemps_KinéId",
                table: "EmploiDuTemps",
                column: "KinéId");

            migrationBuilder.CreateIndex(
                name: "IX_RendezVous_dossierPatientId",
                table: "RendezVous",
                column: "dossierPatientId");

            migrationBuilder.CreateIndex(
                name: "IX_RendezVous_MédecinCorrespondantId",
                table: "RendezVous",
                column: "MédecinCorrespondantId");

            migrationBuilder.CreateIndex(
                name: "IX_RendezVous_MédecinTraitantId",
                table: "RendezVous",
                column: "MédecinTraitantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admissions");

            migrationBuilder.DropTable(
                name: "EmploiDuTemps");

            migrationBuilder.DropTable(
                name: "RendezVous");

            migrationBuilder.DropTable(
                name: "DossierPatients");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }
    }
}
