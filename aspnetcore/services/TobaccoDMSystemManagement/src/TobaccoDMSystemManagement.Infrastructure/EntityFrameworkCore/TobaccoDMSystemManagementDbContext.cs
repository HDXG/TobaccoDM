using Microsoft.EntityFrameworkCore;
using TobaccoDMSystemManagement.Domain.SystemLogs;
using TobaccoDMSystemManagement.Domain.SystemMenus;
using Volo.Abp.EntityFrameworkCore;

namespace TobaccoDMSystemManagement.Infrastructure.EntityFrameworkCore
{
    public class TobaccoDMSystemManagementDbContext(DbContextOptions<TobaccoDMSystemManagementDbContext> options)
        : AbpDbContext<TobaccoDMSystemManagementDbContext>(options)
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
