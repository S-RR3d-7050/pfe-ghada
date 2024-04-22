using System;
using WebApi.Entities;

public class RendezVous { 
        
    public int Id { get; set; }
    public int heureRDV { get; set; }
    public DateTime dateRDV { get; set; }
    public DossierPatient dossierPatient { get; set; }
    public int dossierPatientId { get; set; }
    public int Code { get; set; }
    public string Désignation { get; set; }
    public User MédecinTraitant { get; set; }
    public int MédecinTraitantId { get; set; }
    public User MédecinCorrespondant { get; set; }
    public int MédecinCorrespondantId { get; set; }

}