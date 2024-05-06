namespace WebApi.Models.RDV;

public class RdvUpdate
{

	public int Id { get; set; }
	public int heureRDV { get; set; }
	public DateTime dateRDV { get; set; }
	public int Code { get; set; }
	public string Désignation { get; set; }
	public int dossierPatientId { get; set; }
	public int MédecinTraitantId { get; set; }
	public int MédecinCorrespondantId { get; set; }

}