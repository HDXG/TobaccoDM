using Microsoft.EntityFrameworkCore;
using TobaccoDMAuthorization.DmUsers;
using Volo.Abp;

namespace TobaccoDMAuthorization.EntityFrameworkCore;

public static class TobaccoDMAuthorizationDbContextModelCreatingExtensions
{
    public static void ConfigureProjectName(this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        // 日志表
        builder.Entity<DmUser>(b =>
        {
            b.ToTable("DmUsers", TobaccoDMAuthorizationDomainOptions.DbSchemaName);
            b.HasKey(a => a.Id);

            b.Property(a => a.EncryptionKey.Key).HasColumnName("EncryptionKey");
            b.Property(a => a.EncryptionKey.Key).HasColumnName("EncryptionIv");

            // 忽略字段：尽在程序中使用
            b.Ignore(a => a.EncryptionKey.Encryption);
        });
    }
}