using System;
using WebApi.Entities;

public class RendezVous { 
        
    public int Id { get; set; }
    public int heureRDV { get; set; }
    public DateTime dateRDV { get; set; }
    public DossierPatient dossierPatient { get; set; }
    public int dossierPatientId { get; set; }
    public int Code { get; set; }
    public string D�signation { get; set; }
    public User M�decinTraitant { get; set; }
    public int M�decinTraitantId { get; set; }
    public User M�decinCorrespondant { get; set; }
    public int M�decinCorrespondantId { get; set; }

}