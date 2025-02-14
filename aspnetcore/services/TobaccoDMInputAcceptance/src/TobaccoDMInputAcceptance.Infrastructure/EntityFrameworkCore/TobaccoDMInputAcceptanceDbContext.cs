using Dedsi.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TobaccoDMInputAcceptance.InitialInspections;
using Volo.Abp.Data;

namespace TobaccoDMInputAcceptance.EntityFrameworkCore;

[ConnectionStringName(TobaccoDMInputAcceptanceDomainOptions.ConnectionStringName)]
public class TobaccoDMInputAcceptanceDbContext(DbContextOptions<TobaccoDMInputAcceptanceDbContext> options) 
    : DedsiEfCoreDbContext<TobaccoDMInputAcceptanceDbContext>(options)
{
    public DbSet<InitialInspection> InitialInspections { get; set; }
    
    public DbSet<TobaccoGrower> TobaccoGrowers { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ConfigureProjectName();
    }

}