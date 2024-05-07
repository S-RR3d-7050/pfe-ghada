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
    void Create(RendezVous rendezVous);
    void Update(RendezVous rendezVous);
    void Delete(int id);
    IEnumerable<RendezVous> GetRendezVousByMedecinTraitant(int medecinTraitantId);
    IEnumerable<RendezVous> GetRendezVousByMedecinCorrespondant(int medecinCorrespondantId);
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
            // Include other related entities as needed
            .FirstOrDefault(r => r.Id == id);
    }

    public void Create(RendezVous rendezVous)
    {
        if (rendezVous == null)
            throw new ArgumentNullException(nameof(rendezVous));

        _context.RendezVous.Add(rendezVous);
        _context.SaveChanges();
    }

    public void Update(RendezVous rendezVous)
    {
   

        if (rendezVous == null)
			throw new ArgumentNullException(nameof(rendezVous));

		_context.RendezVous.Update(rendezVous);
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
}