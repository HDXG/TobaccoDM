//using SqlSugar;
//using TobaccoDMSystemManagement.Domain.SystemLogs;

//namespace TobaccoDMSystemManagement.Infrastructure.Repositories.SystemLogs;

//public interface ISystemLogRepository : ISqlSugarRepository<SystemLog>;

//public class SystemLogRepository(ISqlSugarClient dbClient) : SqlSugarRepository<SystemLog>(dbClient), ISystemLogRepository;


using Dedsi.Ddd.Domain.Repositories;
using Dedsi.EntityFrameworkCore.Repositories;
using TobaccoDMSystemManagement.Domain.SystemLogs;
using TobaccoDMSystemManagement.Infrastructure.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

public interface ISystemLogRepository : IDedsiRepository<SystemLog, Guid>;

public class SystemLogRepository(IDbContextProvider<TobaccoDMSystemManagementDbContext> dbContextProvider) : DedsiEfCoreRepository<TobaccoDMSystemManagementDbContext, SystemLog, Guid>(dbContextProvider), ISystemLogRepository;