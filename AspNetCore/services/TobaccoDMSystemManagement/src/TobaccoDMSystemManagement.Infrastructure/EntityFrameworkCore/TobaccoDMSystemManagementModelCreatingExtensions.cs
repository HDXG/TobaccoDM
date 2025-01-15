using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace TobaccoDMSystemManagement.Infrastructure.EntityFrameworkCore
{
    public static class TobaccoDMSystemManagementModelCreatingExtensions
    {
        public static void ConfigureProjectName(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));
        }
    }
}
