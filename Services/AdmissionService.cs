namespace WebApi.Services;

using WebApi.Entities;
using Microsoft.EntityFrameworkCore;
using WebApi.Helpers;

public interface IAdmissionService
{
    IEnumerable<Admission> GetAll();
    Admission GetById(int id);
    void Create(Admission admission);
    void Update(Admission admission);
    void Delete(int id);
    // Additional methods as necessary
    void UpdateWithId(int id, Admission admission);

}


public class AdmissionService: IAdmissionService
{
    private DataContext _context;

    public AdmissionService(DataContext context)
    {
        _context = context;
    }

    public IEnumerable<Admission> GetAll()
    {
        return _context.Admissions.
            Include(a => a.dossierPatient) 
            .Include(a => a.MédecinTraitant)
            .Include(a => a.MédecinCorrespondant)
            .Include(a => a.MédecinPrescripteur)
            .ToList();
    }

    public Admission GetById(int id)
    {
        return _context.Admissions
            .Include(a => a.dossierPatient) // Assuming you need to include related data
            .Include(a => a.MédecinTraitant)
            .Include(a => a.MédecinCorrespondant)
            .Include(a => a.MédecinPrescripteur)                        // Add any other necessary includes for related entities
            .FirstOrDefault(a => a.Id == id);
    }

    public void Create(Admission admission)
    {
        if (admission == null)
            throw new ArgumentNullException(nameof(admission));

        // Any additional business rules and validations go here

        _context.Admissions.Add(admission);
        _context.SaveChanges();


    }

    public void Update(Admission admission)
    {
        if (admission == null)
            throw new ArgumentNullException(nameof(admission));

        // Any additional business rules and validations go here

        _context.Admissions.Update(admission);
        _context.SaveChanges();
    }

    public void UpdateWithId(int id, Admission admissionUpdate)
    {
        var admission = _context.Admissions.Find(id);
        if (admission == null)
            throw new InvalidOperationException("Admission not found");

        var properties = typeof(Admission).GetProperties();
        foreach (var property in properties)
        {
            var newValue = property.GetValue(admissionUpdate, null);
            if (newValue != null) // Ensures we only update properties that have been set in the DTO
            {
                var entityProperty = _context.Entry(admission).Property(property.Name);
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
        var admission = _context.Admissions.Find(id);
        if (admission == null)
            throw new InvalidOperationException("Admission not found");

        _context.Admissions.Remove(admission);
        _context.SaveChanges();
    }

    // Additional methods as necessary
}
