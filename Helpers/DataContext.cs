namespace WebApi.Helpers;

using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

public class DataContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to sql server database
        options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Admission> Admissions { get; set; }
    public DbSet<DossierPatient> DossierPatients { get; set; }
    public DbSet<EmploiDuTemps> EmploiDuTemps { get; set; }
    public DbSet<RendezVous> RendezVous { get; set; }

}