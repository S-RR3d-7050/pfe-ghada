namespace WebApi.Entities;

using System;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Entities;

public class RendezVous {

    public int Id { get; set; }
    public int heureRDV { get; set; }
    public DateTime dateRDV { get; set; }
    public int Code { get; set; }
    public string Désignation { get; set; }

    [ForeignKey("dossierPatientId")]
    public DossierPatient dossierPatient { get; set; }
    public int dossierPatientId { get; set; }

    [ForeignKey("MédecinTraitantId")]
    public User MédecinTraitant { get; set; }
    public int MédecinTraitantId { get; set; }

    [ForeignKey("MédecinCorrespondantId")]
    public User MédecinCorrespondant { get; set; }
    public int MédecinCorrespondantId { get; set; }

}