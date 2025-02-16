using Microsoft.EntityFrameworkCore;
using TobaccoDMSystemManagement.Domain;
using TobaccoDMSystemManagement.Domain.SystemLogs;
using TobaccoDMSystemManagement.Domain.SystemMenus;
using Volo.Abp;

namespace TobaccoDMSystemManagement.Infrastructure.EntityFrameworkCore
{
    public static class TobaccoDMSystemManagementDbContextModelCreatingExtensions
    {
        public static void ConfigureProjectName(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));
            builder.Entity<SystemLog>(b =>
            {
                b.ToTable("system_log", TobaccoDMSystemManagementConsts.DbSchemaName);
                b.HasKey(a => a.Id);
            });

            builder.Entity<SystemMenu>(b =>
            {
                b.ToTable("system_menu", TobaccoDMSystemManagementConsts.DbSchemaName);
                b.HasKey(a => a.Id);
                b.HasMany(c => c.SubMenus).WithOne().HasForeignKey("ParentId").OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
