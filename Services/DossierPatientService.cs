namespace WebApi.Services;

using WebApi.Entities;
using Microsoft.EntityFrameworkCore;
using WebApi.Helpers;
using System;
using System.Linq;
using System.Collections.Generic;
using WebApi.Models.DossiersPatients;

public interface IDossierPatientService
{
    IEnumerable<DossierPatient> GetAll();
    DossierPatient GetById(int id);
    void Create(DossierPatient dossierPatient);
    void Update(DossierPatient dossierPatient);
    void UpdateWithId(int id, DPUpdate updateModel);
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

    //public void UpdateWithId(int id, DossierPatient dossierPatient)
    //{

    //    var dossierPatient = _context.DossierPatients.Find(id);
    //    if (dossierPatient == null)
    //        throw new InvalidOperationException("DossierPatient not found");

    //    _context.DossierPatients.Update(dossierPatient);
    //    _context.SaveChanges();

    //}

    //public void UpdateWithId(int id, DossierPatient dossierPatient)
    //{
    //    var foundDossierPatient = _context.DossierPatients.Find(id);
    //    //if (foundDossierPatient == null)
    //    //    throw new InvalidOperationException("DossierPatient not found");

    //    //_context.Entry(foundDossierPatient).CurrentValues.SetValues(dossierPatient);
    //    //_context.SaveChanges();

    //    if (foundDossierPatient == null)
    //        throw new InvalidOperationException("DossierPatient not found");

    //    // Update the properties of the foundDossierPatient with the properties from dossierPatient

    //}

    public void UpdateWithId(int id, DPUpdate updateModel)
    {
        var dossierPatient = _context.DossierPatients.Find(id);
        if (dossierPatient == null)
            throw new InvalidOperationException("DossierPatient not found");

        var properties = typeof(DPUpdate).GetProperties();
        foreach (var property in properties)
        {
            var newValue = property.GetValue(updateModel, null);
            if (newValue != null) // Ensures we only update properties that have been set in the DTO
            {
                var entityProperty = _context.Entry(dossierPatient).Property(property.Name);
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
        var dossier = _context.DossierPatients.Find(id);
        if (dossier == null)
            throw new InvalidOperationException("DossierPatient not found");

        _context.DossierPatients.Remove(dossier);
        _context.SaveChanges();
    }
}