using Microsoft.EntityFrameworkCore;
using SoVet.Data.Entities;

namespace SoVet.Data;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }
    
    public DbSet<Appointment> Appointments { get; set; } = null!;

    public DbSet<AppointmentDiagnosis> AppointmentDiagnoses { get; set; } = null!;
    
    public DbSet<AppointmentFacility> AppointmentFacilities { get; set; } = null!;
    
    public DbSet<Client> Clients { get; set; } = null!;
    
    public DbSet<ClinicSchedule> ClinicSchedules { get; set; } = null!;
    
    public DbSet<Diagnosis> Diagnoses { get; set; } = null!;
    
    public DbSet<Employee> Employees { get; set; } = null!;
    
    public DbSet<Facility> Facilities { get; set; } = null!;
    
    public DbSet<FacilityCategory> FacilityCategories { get; set; } = null!;
    
    public DbSet<Patient> Patients { get; set; } = null!;
    
    public DbSet<Payment> Payments { get; set; } = null!;
    
    public DbSet<Recommendation> Recommendations { get; set; } = null!;
    
    public DbSet<Registration> Registrations { get; set; } = null!;
    
    public DbSet<RegistrationType> RegistrationTypes { get; set; } = null!;
    
    public DbSet<Vaccination> Vaccinations { get; set; } = null!;
    
    public DbSet<ValueAddedTax> ValueAddedTaxes { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}