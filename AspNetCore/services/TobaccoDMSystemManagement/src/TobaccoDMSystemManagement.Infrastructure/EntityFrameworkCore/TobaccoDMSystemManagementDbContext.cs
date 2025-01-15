using Dedsi.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TobaccoDMSystemManagement.Domain;
using Volo.Abp.Data;

namespace TobaccoDMSystemManagement.Infrastructure.EntityFrameworkCore
{

    [ConnectionStringName(TobaccoDMSystemManagementDomainOptions.ConnectionStringName)]
    public class TobaccoDMSystemManagementDbContext(DbContextOptions<TobaccoDMSystemManagementDbContext> dbContextOptions): DedsiEfCoreDbContext<TobaccoDMSystemManagementDbContext>(dbContextOptions)
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ConfigureProjectName();
        }
    }
}
