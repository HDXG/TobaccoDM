
using TobaccoDMSystemManagement.Domain.SystemLogs;
using TobaccoDMSystemManagement.Infrastructure.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

public interface ISystemLogRepository : IRepository<SystemLog, Guid>;

public class SystemLogRepository(IDbContextProvider<TobaccoDMSystemManagementDbContext> dbContextProvider) : EfCoreRepository<TobaccoDMSystemManagementDbContext, SystemLog, Guid>(dbContextProvider), ISystemLogRepository;