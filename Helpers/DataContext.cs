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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Admission>()
            .HasOne(a => a.M�decinTraitant)
            .WithMany() // Replace with .WithMany(u => u.Admissions) if User has a collection of Admissions
            .HasForeignKey(a => a.M�decinTraitantId)
            .OnDelete(DeleteBehavior.Restrict); // Adjust the DeleteBehavior as required

        modelBuilder.Entity<Admission>()
            .HasOne(a => a.M�decinCorrespondant)
            .WithMany() // Replace with .WithMany(u => u.Admissions) if User has a collection of Admissions
            .HasForeignKey(a => a.M�decinCorrespondantId)
            .OnDelete(DeleteBehavior.Restrict); // Adjust the DeleteBehavior as required

        modelBuilder.Entity<Admission>()
            .HasOne(a => a.M�decinPrescripteur)
			.WithMany() // Replace with .WithMany(u => u.Admissions) if User has a collection of Admissions
			.HasForeignKey(a => a.M�decinPrescripteurId)
			.OnDelete(DeleteBehavior.Restrict); // Adjust the DeleteBehavior as required

        modelBuilder.Entity<EmploiDuTemps>()
        .HasOne(et => et.Kin�)
        .WithMany() // Replace with .WithMany(u => u.EmploiDuTemps) if User has a collection of EmploiDuTemps
        .HasForeignKey(et => et.Kin�Id)
        .OnDelete(DeleteBehavior.Restrict); // Or another appropriate delete behavior

        modelBuilder.Entity<RendezVous>()
        .HasOne(rdv => rdv.dossierPatient)
        .WithMany() // Replace with .WithMany(dp => dp.RendezVous) if DossierPatient has a collection of RendezVous
        .HasForeignKey(rdv => rdv.dossierPatientId);

        modelBuilder.Entity<RendezVous>()
            .HasOne(rdv => rdv.M�decinTraitant)
            .WithMany() // If necessary
            .HasForeignKey(rdv => rdv.M�decinTraitantId)
            .OnDelete(DeleteBehavior.Restrict); // Or another appropriate delete behavior

        modelBuilder.Entity<RendezVous>()
            .HasOne(rdv => rdv.M�decinCorrespondant)
            .WithMany() // If necessary
            .HasForeignKey(rdv => rdv.M�decinCorrespondantId)
            .OnDelete(DeleteBehavior.Restrict); // Or another appropriate delete behavior

    }



}