using System;
using WebApi.Entities;

public class Admission
{
    public int Id { get; set; }
    public DossierPatient dossierPatient { get; set; }
    public int dossierPatientId { get; set; }
    public int Identifiant { get; set; }
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public DateTime DateNaissance { get; set; }
    public string Nationnalité { get; set; }
    public string Type { get; set; }
    public string Adresse { get; set; }
    public string Telephone { get; set; }
    public int NumCIN { get; set; }
    public string Société { get; set; }
    public string Matricule { get; set; }
    public DateTime DatePEC { get; set; }
    public int NumPEC { get; set; }
    public User MédecinTraitant { get; set; }
    public int MédecinTraitantId { get; set; }
    public User MédecinCorrespondant { get; set; }
    public int MédecinCorrespondantId { get; set; }
    public string Code { get; set; }
    public string Désignation { get; set; }
    public string SJour { get; set; }
    public string Jour { get; set; }
    public string Période { get; set; }
    public string Chambre { get; set; }

}