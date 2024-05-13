namespace WebApi.Services;

using AutoMapper;
using WebApi.Entities;
using Microsoft.EntityFrameworkCore;
using WebApi.Helpers;
using System;
using System.Linq;
using System.Collections.Generic;
using WebApi.Models.RDV;

public interface IRendezVousService
{
    IEnumerable<RendezVous> GetAll();
    RendezVous GetById(int id);
    RendezVous Create(RendezVous rendezVous);
    void Update(RendezVous rendezVous);
    void Delete(int id);
    IEnumerable<RendezVous> GetRendezVousByMedecinTraitant(int medecinTraitantId);
    IEnumerable<RendezVous> GetRendezVousByMedecinCorrespondant(int medecinCorrespondantId);
    void UpdateWithId(int id, RdvUpdate rdvUpdate);
    IEnumerable<RendezVous> GetRendezVousByMedecinTraitantAndCorrespondant(int medecinId);
}

public class RendezVousService : IRendezVousService
{

	private readonly IMapper _mapper;
	private DataContext _context;

    public RendezVousService(DataContext context, IMapper mapper)
    {
        _context = context;
		_mapper = mapper;


	}

	public IEnumerable<RendezVous> GetAll()
    {
        return _context.RendezVous
            .Include(r => r.dossierPatient)
            .Include(r => r.MédecinTraitant)
            .Include(r => r.MédecinCorrespondant)
            // You might also need to include MédecinTraitant and MédecinCorrespondant
            .ToList();
    }

    public RendezVous GetById(int id)
    {
        return _context.RendezVous
            .Include(r => r.dossierPatient)
            .Include(r => r.MédecinTraitant)
            .Include(r => r.MédecinCorrespondant)
            // Include other related entities as needed
            .FirstOrDefault(r => r.Id == id);
    }

    public RendezVous Create(RendezVous rendezVous)
    {
        if (rendezVous == null)
            throw new ArgumentNullException(nameof(rendezVous));

        //_context.RendezVous.Add(rendezVous);
        //_context.SaveChanges();

        //save the new rendez-vous and return it with the related entities
        _context.RendezVous.Add(rendezVous);
        _context.SaveChanges();

        int id = rendezVous.Id;

        var rendezVousAdded = _context.RendezVous
            .Include(r => r.dossierPatient)
            .Include(r => r.MédecinTraitant)
            .Include(r => r.MédecinCorrespondant)
            .FirstOrDefault(r => r.Id == id);


        return rendezVousAdded;
    }

    public void Update(RendezVous rendezVous)
    {
   

        if (rendezVous == null)
			throw new ArgumentNullException(nameof(rendezVous));

		_context.RendezVous.Update(rendezVous);
		_context.SaveChanges();


    }

    public void UpdateWithId(int id, RdvUpdate rdvUpdate)
    {
        var rendezVous = _context.RendezVous.Find(id);
        if (rendezVous == null)
            throw new InvalidOperationException("RendezVous not found");

        var properties = typeof(RdvUpdate).GetProperties();
        foreach (var property in properties)
        {
            var newValue = property.GetValue(rdvUpdate, null);
            if (newValue != null) // Ensures we only update properties that have been set in the DTO
            {
                var entityProperty = _context.Entry(rendezVous).Property(property.Name);
                if (entityProperty != null && entityProperty.Metadata.Name != "Id") // Ensure we do not try to update the ID
                {
                    entityProperty.CurrentValue = newValue;
                    entityProperty.IsModified = true;
                }
            }
        }   

        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var rendezVous = _context.RendezVous.Find(id);
        if (rendezVous == null)
            throw new InvalidOperationException("RendezVous not found");

        _context.RendezVous.Remove(rendezVous);
        _context.SaveChanges();
    }

    // get all rendez-vous for a specific MédecinTraitant
    public IEnumerable<RendezVous> GetRendezVousByMedecinTraitant(int medecinTraitantId)
    {
		return _context.RendezVous
			.Include(r => r.dossierPatient)
			.Where(r => r.MédecinTraitantId == medecinTraitantId)
			.ToList();
	}

    public IEnumerable<RendezVous> GetRendezVousByMedecinCorrespondant(int medecinCorrespondantId)
    {
        return _context.RendezVous
            .Include(r => r.dossierPatient)
            .Where(r => r.MédecinCorrespondantId == medecinCorrespondantId)
            .ToList();
    }

    public IEnumerable<RendezVous> GetRendezVousByMedecinTraitantAndCorrespondant(int medecinId)
    {
        return _context.RendezVous
            .Include(r => r.dossierPatient)
            .Include(r => r.MédecinTraitant)
            .Include(r => r.MédecinCorrespondant)
            .Where(r => r.MédecinTraitantId == medecinId || r.MédecinCorrespondantId == medecinId)
            .ToList();
    }


}