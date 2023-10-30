using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SoVet.Auth.Models;

namespace SoVet.Auth;

public class IdentityContext : IdentityDbContext<ClinicUser, ClinicRole, int>
{
    public IdentityContext(DbContextOptions options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema("identity");
        base.OnModelCreating(builder);
    }
}

public sealed class MigrationApplicationContext : IDesignTimeDbContextFactory<IdentityContext>
{
    public IdentityContext CreateDbContext(string[] args)
    {
        var options = new DbContextOptionsBuilder<IdentityContext>()
            .UseNpgsql("test")
            .UseSnakeCaseNamingConvention()
            .Options;
        return new IdentityContext(options);
    }
}