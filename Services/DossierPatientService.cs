namespace WebApi.Services;

using WebApi.Entities;
using Microsoft.EntityFrameworkCore;
using WebApi.Helpers;
using System;
using System.Linq;
using System.Collections.Generic;

public interface IDossierPatientService
{
    IEnumerable<DossierPatient> GetAll();
    DossierPatient GetById(int id);
    void Create(DossierPatient dossierPatient);
    void Update(DossierPatient dossierPatient);
    void Delete(int id);
}


public class DossierPatientService : IDossierPatientService
{
    private DataContext _context;

    public DossierPatientService(DataContext context)
    {
        _context = context;
    }

    public IEnumerable<DossierPatient> GetAll()
    {
        return _context.DossierPatients;
    }

    public DossierPatient GetById(int id)
    {
        return _context.DossierPatients.Find(id);
    }

    public void Create(DossierPatient dossierPatient)
    {
        if (dossierPatient == null)
            throw new ArgumentNullException(nameof(dossierPatient));

        _context.DossierPatients.Add(dossierPatient);
        _context.SaveChanges();
    }

    public void Update(DossierPatient dossierPatient)
    {
        if (dossierPatient == null)
            throw new ArgumentNullException(nameof(dossierPatient));

        _context.DossierPatients.Update(dossierPatient);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var dossier = _context.DossierPatients.Find(id);
        if (dossier == null)
            throw new InvalidOperationException("DossierPatient not found");

        _context.DossierPatients.Remove(dossier);
        _context.SaveChanges();
    }
}