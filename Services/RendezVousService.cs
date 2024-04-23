namespace WebApi.Services;

using WebApi.Entities;
using Microsoft.EntityFrameworkCore;
using WebApi.Helpers;
using System;
using System.Linq;
using System.Collections.Generic;

public interface IRendezVousService
{
    IEnumerable<RendezVous> GetAll();
    RendezVous GetById(int id);
    void Create(RendezVous rendezVous);
    void Update(RendezVous rendezVous);
    void Delete(int id);
}

public class RendezVousService : IRendezVousService
{
    private DataContext _context;

    public RendezVousService(DataContext context)
    {
        _context = context;
    }

    public IEnumerable<RendezVous> GetAll()
    {
        return _context.RendezVous
            .Include(r => r.dossierPatient)
            // You might also need to include M�decinTraitant and M�decinCorrespondant
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
}