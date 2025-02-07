using TobaccoDMSystemManagement.AppService.SystemMenus.Dtos;
using TobaccoDMSystemManagement.Domain.SystemMenus;
using TobaccoDMSystemManagement.Infrastructure.Repositories.SystemMenus;
using TobaccoDMSystemManagement.Infrastructure.Utils;

namespace TobaccoDMSystemManagement.AppService.SystemMenus
{
    public interface ISystemMenuAppService : ITobaccoDMSystemManagementAppService
    {
        Task<bool> ChangeSystemMenu(SystemMenuDto request);

        Task<SystemMenuDto> GetSystemMenu(Guid id);
    }

    public class SystemMenuAppService(ISystemMenuRepository systemMenuRepository) : TobaccoDMSystemManagementAppService, ISystemMenuAppService
    {
        public Task<bool> ChangeSystemMenu(SystemMenuDto request)
        {
            SystemMenu systemMenu = MapsterConfig.MapsterTo<SystemMenuDto, SystemMenu>(request);
            if (request.Id == Guid.Empty)
            {
                systemMenu.CreateIdTime(GuidGenerator.Create());
                systemMenu.SavaUpdateTime();
                return systemMenuRepository.InsertAsync(systemMenu);
            }
            else
            {
                systemMenu.SavaUpdateTime();
                return systemMenuRepository.UpdateAsync(systemMenu);
            }
        }

        public async Task<SystemMenuDto> GetSystemMenu(Guid id) => MapsterConfig.MapsterTo<SystemMenu, SystemMenuDto>(await systemMenuRepository.GetAsync(x => x.Id == id));
    }
}
