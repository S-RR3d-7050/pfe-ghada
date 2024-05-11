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
    EmploiDuTemps GetByKin�Id(int kin�Id);
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
            .Include(e => e.Kin�) // Assuming you need to include related data
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

    public void Delete(int id)
    {
        var emploi = _context.EmploiDuTemps.Find(id);
        if (emploi == null)
            throw new InvalidOperationException("EmploiDuTemps not found");

        _context.EmploiDuTemps.Remove(emploi);
        _context.SaveChanges();
    }

    public EmploiDuTemps GetByKin�Id(int kin�Id)
    {
        return _context.EmploiDuTemps
            .Include(e => e.Kin�)
            .FirstOrDefault(e => e.Kin�Id == kin�Id);
    }   
}