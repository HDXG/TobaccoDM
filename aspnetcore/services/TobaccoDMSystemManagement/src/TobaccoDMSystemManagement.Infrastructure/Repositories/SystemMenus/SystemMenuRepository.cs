using TobaccoDMSystemManagement.Domain.Repositories;
using TobaccoDMSystemManagement.Domain.SystemMenus;
using TobaccoDMSystemManagement.Infrastructure.EntityFrameworkCore;
using TobaccoDMSystemManagement.Infrastructure.Repositories;
using Volo.Abp.EntityFrameworkCore;

public interface ISystemMenuRepository : ITobaccoDMRepository<SystemMenu, Guid>;

public class SystemMenuRepository(IDbContextProvider<TobaccoDMSystemManagementDbContext> dbContextProvider) :TobaccoDMRepository<SystemMenu, Guid>(dbContextProvider),ISystemMenuRepository
{
    
}


