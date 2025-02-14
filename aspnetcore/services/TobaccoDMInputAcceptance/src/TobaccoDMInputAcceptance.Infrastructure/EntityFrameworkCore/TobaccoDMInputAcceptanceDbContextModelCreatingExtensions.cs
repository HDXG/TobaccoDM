using Microsoft.EntityFrameworkCore;
using TobaccoDMInputAcceptance.InitialInspections;
using Volo.Abp;

namespace TobaccoDMInputAcceptance.EntityFrameworkCore;

public static class TobaccoDMInputAcceptanceDbContextModelCreatingExtensions
{
    public static void ConfigureProjectName(this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        builder.Entity<InitialInspection>(b =>
        {
            b.ToTable("InitialInspections", TobaccoDMInputAcceptanceDomainOptions.DbSchemaName);
            b.HasKey(x => x.Id);

            // 值对象
            // 从属实体类型
            b.OwnsOne(p => p.InitialInspector, c =>
            {
                c.Property(x => x.UserId).HasColumnName("InspectorUserId");
                c.Property(x => x.UserName).HasColumnName("InspectorUserName");
                c.Property(x => x.DeptId).HasColumnName("InspectorDeptId");
            });
            
            // 一对多
            b.HasMany(e => e.TobaccoGrowers)
                .WithOne()
                .HasForeignKey(e => e.InitialInspectionId)
                .IsRequired();
        });
        
        builder.Entity<TobaccoGrower>(b =>
        {
            b.ToTable("TobaccoGrowers", TobaccoDMInputAcceptanceDomainOptions.DbSchemaName);
            b.HasKey(x => x.Id);
        });
    }
}