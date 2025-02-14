using TobaccoDMSystemManagement.Domain.SystemMenus;
using TobaccoDMSystemManagement.Infrastructure.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

public interface ISystemMenuRepository : IRepository<SystemMenu,Guid>;

public class SystemMenuRepository(IDbContextProvider<TobaccoDMSystemManagementDbContext> dbContextProviders) 
    : EfCoreRepository<TobaccoDMSystemManagementDbContext, SystemMenu,Guid>(dbContextProviders), 
        ISystemMenuRepository;


