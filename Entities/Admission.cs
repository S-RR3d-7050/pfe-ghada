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
    public string Nationnalit� { get; set; }
    public string Type { get; set; }
    public string Adresse { get; set; }
    public string Telephone { get; set; }
    public int NumCIN { get; set; }
    public string Soci�t� { get; set; }
    public string Matricule { get; set; }
    public DateTime DatePEC { get; set; }
    public int NumPEC { get; set; }
    public User M�decinTraitant { get; set; }
    public int M�decinTraitantId { get; set; }
    public User M�decinCorrespondant { get; set; }
    public int M�decinCorrespondantId { get; set; }
    public string Code { get; set; }
    public string D�signation { get; set; }
    public string SJour { get; set; }
    public string Jour { get; set; }
    public string P�riode { get; set; }
    public string Chambre { get; set; }

}