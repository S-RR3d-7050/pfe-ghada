namespace WebApi.Services;

using WebApi.Entities;
using Microsoft.EntityFrameworkCore;
using WebApi.Helpers;
using System;
using System.Linq;
using System.Collections.Generic;


public interface IEmploiDuTempsService
{
    IEnumerable<EmploiDuTemps> GetAll();
    EmploiDuTemps GetById(int id);
    void Create(EmploiDuTemps emploiDuTemps);
    void Update(EmploiDuTemps emploiDuTemps);
    void Delete(int id);
    EmploiDuTemps GetByKinéId(int kinéId);
    void UpdateWithId(int id, EmploiDuTemps emploiDuTempsUpdate);
}

public class EmploiDuTempsService : IEmploiDuTempsService
{
    private DataContext _context;

    public EmploiDuTempsService(DataContext context)
    {
        _context = context;
    }

    public IEnumerable<EmploiDuTemps> GetAll()
    {
        return _context.EmploiDuTemps;
    }

    public EmploiDuTemps GetById(int id)
    {
        return _context.EmploiDuTemps
            .Include(e => e.Kiné) // Assuming you need to include related data
            .FirstOrDefault(e => e.Id == id);
    }

    public void Create(EmploiDuTemps emploiDuTemps)
    {
        if (emploiDuTemps == null)
            throw new ArgumentNullException(nameof(emploiDuTemps));

        _context.EmploiDuTemps.Add(emploiDuTemps);
        _context.SaveChanges();
    }

    public void Update(EmploiDuTemps emploiDuTemps)
    {
        if (emploiDuTemps == null)
            throw new ArgumentNullException(nameof(emploiDuTemps));

        _context.EmploiDuTemps.Update(emploiDuTemps);
        _context.SaveChanges();
    }

    public void UpdateWithId(int id, EmploiDuTemps emploiDuTempsUpdate)
    {
       try
        {
            var emploiDuTemps = _context.EmploiDuTemps.Find(id);
            if (emploiDuTemps == null)
                throw new InvalidOperationException("Emlpoi du temps not found");

            var properties = typeof(EmploiDuTemps).GetProperties();
            foreach (var property in properties)
            {
                var newValue = property.GetValue(emploiDuTempsUpdate, null);
                if (newValue != null) // Ensures we only update properties that have been set in the DTO
                {
                    var entityProperty = _context.Entry(emploiDuTemps).Property(property.Name);
                    if (entityProperty != null && entityProperty.Metadata.Name != "Id") // Ensure we do not try to update the ID
                    {
                        entityProperty.CurrentValue = newValue;
                        entityProperty.IsModified = true;
                    }
                }
            }

            _context.SaveChanges();
        } catch (Exception ex)
        {
            throw new InvalidOperationException(ex.Message);
        }
    }

    public void Delete(int id)
    {
        var emploi = _context.EmploiDuTemps.Find(id);
        if (emploi == null)
            throw new InvalidOperationException("EmploiDuTemps not found");

        _context.EmploiDuTemps.Remove(emploi);
        _context.SaveChanges();
    }

    public EmploiDuTemps GetByKinéId(int kinéId)
    {
        return _context.EmploiDuTemps
            .Include(e => e.Kiné)
            .FirstOrDefault(e => e.KinéId == kinéId);
    }   
}