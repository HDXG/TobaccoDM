using Dedsi.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TobaccoDMSystemManagement.Domain.SystemLogs;
using TobaccoDMSystemManagement.Domain.SystemMenus;

namespace TobaccoDMSystemManagement.Infrastructure.EntityFrameworkCore
{
    public class TobaccoDMSystemManagementDbContext(DbContextOptions<TobaccoDMSystemManagementDbContext> options)
        : DedsiEfCoreDbContext<TobaccoDMSystemManagementDbContext>(options)
    {
        public DbSet<SystemLog> SystemLogs { get; set; }

        public DbSet<SystemMenu> SystemMenus { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ConfigureProjectName();
        }
    }
}
