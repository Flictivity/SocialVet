using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SoVet.Data.Entities;

namespace SoVet.Data;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }
    
    public DbSet<Appointment> Appointments { get; set; } = null!;
    
    public DbSet<AppointmentFacility> AppointmentFacilities { get; set; } = null!;
    
    public DbSet<Client> Clients { get; set; } = null!;
    
    public DbSet<Clinic> ClinicSchedules { get; set; } = null!;
    
    public DbSet<Diagnosis> Diagnoses { get; set; } = null!;
    
    public DbSet<Employee> Employees { get; set; } = null!;
    
    public DbSet<Facility> Facilities { get; set; } = null!;
    
    public DbSet<FacilityCategory> FacilityCategories { get; set; } = null!;
    
    public DbSet<Patient> Patients { get; set; } = null!;
    public DbSet<Registration> Registrations { get; set; } = null!;
    
    public DbSet<AnimalType> AnimalType { get; set; } = null!;
}

public sealed class MigrationApplicationContext : IDesignTimeDbContextFactory<ApplicationContext>
{
    public ApplicationContext CreateDbContext(string[] args)
    {
        var options = new DbContextOptionsBuilder<ApplicationContext>()
            .UseNpgsql("Host=localhost;Port=7432;Database=social_vet;Username=postgres;Password=postgreS12;")
            .UseSnakeCaseNamingConvention()
            .Options;
        return new ApplicationContext(options);
    }
}