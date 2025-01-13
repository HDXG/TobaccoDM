using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace TobaccoDMAuthorization.EntityFrameworkCore;

public static class TobaccoDMAuthorizationDbContextModelCreatingExtensions
{
    public static void ConfigureProjectName(this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

    }
}