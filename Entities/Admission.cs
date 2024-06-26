
namespace WebApi.Entities;

using System;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Entities;

public class Admission
{
    public int Id { get; set; }
    public DossierPatient dossierPatient { get; set; }
    public int dossierPatientId { get; set; }
    public string Type { get; set; }
    public string Société { get; set; }
    public string Matricule { get; set; }
    public DateTime DatePEC { get; set; }
    public int NumPEC { get; set; }

    [ForeignKey("MédecinTraitantId")]
    public User MédecinTraitant { get; set; }
    public int MédecinTraitantId { get; set; }

    [ForeignKey("MédecinCorrespondantId")]
    public User MédecinCorrespondant { get; set; }
    public int MédecinCorrespondantId { get; set; }

    [ForeignKey("MédecinPrescripteurId")]
    public User MédecinPrescripteur { get; set; }
    public int MédecinPrescripteurId { get; set; }

    public string Code { get; set; }
    public string Désignation { get; set; }
    public string SJour { get; set; }
    public string Jour { get; set; }
    public string Période { get; set; }
    public string Chambre { get; set; }

}