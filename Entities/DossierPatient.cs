namespace WebApi.Entities;

using System;
using WebApi.Entities;

public class DossierPatient
{

    public int Id { get; set; }
    public string NomCli { get; set; }
    public string Prenom { get; set; }
    public int NumCIN { get; set; }
    public string Sex { get; set; }
    public string Empreinte { get; set; }
    public string Email { get; set; }
    public string Telephone { get; set; }
    public string Pays { get; set; }
    public string Prenom2 { get; set; }
    public DateTime DatNai { get; set; }
    public string Nationnalité { get; set; }
    public string AdrChi { get; set; }
    public string AdresseLocale { get; set; }
    public DateTime DatCIN { get; set; }
    public string PrenomPere { get; set; }
    public string Prestataire { get; set; }
    public string Traite { get; set; }
    public string Tel2 { get; set; }
    public string Gouvernorat { get; set; }
    public string CodePostale { get; set; }
    public string Délégation { get; set; }
    public string Matricule { get; set; }
    public string PatientPEC { get; set; }
    public string TypPCE { get; set; }
    public string Lieu { get; set; }
}