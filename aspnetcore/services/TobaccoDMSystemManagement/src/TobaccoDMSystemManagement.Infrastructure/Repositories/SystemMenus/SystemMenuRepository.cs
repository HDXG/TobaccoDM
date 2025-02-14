//using SqlSugar;
//using TobaccoDMSystemManagement.Domain.SystemMenus;

//namespace TobaccoDMSystemManagement.Infrastructure.Repositories.SystemMenus;

//public interface ISystemMenuRepository:ISqlSugarRepository<SystemMenu>;

//public class SystemMenuRepository(ISqlSugarClient sqlSugarClient) : SqlSugarRepository<SystemMenu>(sqlSugarClient), ISystemMenuRepository;


using Dedsi.Ddd.Domain.Repositories;
using Dedsi.EntityFrameworkCore.Repositories;
using TobaccoDMSystemManagement.Domain.SystemMenus;
using TobaccoDMSystemManagement.Infrastructure.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

public interface ISystemMenuRepository : IDedsiRepository<SystemMenu,Guid>;

public class SystemMenuRepository(IDbContextProvider<TobaccoDMSystemManagementDbContext> dbContextProviders) : DedsiEfCoreRepository<TobaccoDMSystemManagementDbContext, SystemMenu,Guid>(dbContextProviders), ISystemMenuRepository;


