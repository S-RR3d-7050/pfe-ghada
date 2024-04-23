using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations.SqlServerMigrations
{
    public partial class RunningMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DossierPatients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomCli = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumCIN = table.Column<int>(type: "int", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Empreinte = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pays = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenom2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatNai = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nationnalité = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdrChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdresseLocale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatCIN = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrenomPere = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prestataire = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Traite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tel2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gouvernorat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodePostale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Délégation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Matricule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientPEC = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DossierPatients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CIN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Admissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dossierPatientId = table.Column<int>(type: "int", nullable: false),
                    Identifiant = table.Column<int>(type: "int", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateNaissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nationnalité = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumCIN = table.Column<int>(type: "int", nullable: false),
                    Société = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Matricule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatePEC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumPEC = table.Column<int>(type: "int", nullable: false),
                    MédecinTraitantId = table.Column<int>(type: "int", nullable: false),
                    MédecinCorrespondantId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Désignation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SJour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Jour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Période = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Chambre = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Admissions_Users_MédecinTraitantId",
                        column: x => x.MédecinTraitantId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmploiDuTemps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KinéId = table.Column<int>(type: "int", nullable: false),
                    DateEmploi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HDébutMatinée = table.Column<TimeSpan>(type: "time", nullable: false),
                    HFinMatinée = table.Column<TimeSpan>(type: "time", nullable: false),
                    HDebutApMidi = table.Column<TimeSpan>(type: "time", nullable: false),
                    HFinApMidi = table.Column<TimeSpan>(type: "time", nullable: false),
                    HDébutSoir = table.Column<TimeSpan>(type: "time", nullable: false),
                    HFinSoir = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploiDuTemps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmploiDuTemps_Users_KinéId",
                        column: x => x.KinéId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RendezVous",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    heureRDV = table.Column<int>(type: "int", nullable: false),
                    dateRDV = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Désignation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dossierPatientId = table.Column<int>(type: "int", nullable: false),
                    MédecinTraitantId = table.Column<int>(type: "int", nullable: false),
                    MédecinCorrespondantId = table.Column<int>(type: "int", nullable: false)
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RendezVous_Users_MédecinTraitantId",
                        column: x => x.MédecinTraitantId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
