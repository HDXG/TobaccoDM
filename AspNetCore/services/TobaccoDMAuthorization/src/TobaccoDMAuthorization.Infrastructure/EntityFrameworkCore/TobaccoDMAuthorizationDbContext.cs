using Dedsi.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;

namespace TobaccoDMAuthorization.EntityFrameworkCore;

[ConnectionStringName(TobaccoDMAuthorizationDomainOptions.ConnectionStringName)]
public class TobaccoDMAuthorizationDbContext(DbContextOptions<TobaccoDMAuthorizationDbContext> options) 
    : DedsiEfCoreDbContext<TobaccoDMAuthorizationDbContext>(options)
{


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ConfigureProjectName();
    }

}