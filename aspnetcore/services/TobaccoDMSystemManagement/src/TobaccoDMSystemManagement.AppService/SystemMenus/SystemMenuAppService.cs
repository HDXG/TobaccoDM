using TobaccoDMSystemManagement.AppService.SystemMenus.Dtos;
using TobaccoDMSystemManagement.Infrastructure.Repositories.SystemMenus;

namespace TobaccoDMSystemManagement.AppService.SystemMenus;

public interface ISystemMenuAppService : ITobaccoDMSystemManagementAppService
{
    /// <summary>
    /// 单个菜单信息
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<SystemMenuDto> GetSystemMenuAsync(Guid id);
}

public class SystemMenuAppService(ISystemMenuRepository systemMenuRepository) : TobaccoDMSystemManagementAppService, ISystemMenuAppService
{
    /// <inheritdoc />
    public async Task<SystemMenuDto> GetSystemMenuAsync(Guid id)
    {
        var entity = await systemMenuRepository.GetAsync(x => x.Id == id);

        return new SystemMenuDto()
        {
            Id = entity.Id,
            MenuName = entity.MenuName,
            ParentMenuID = entity.ParentMenuID,
            MenuType = entity.MenuType,
            MenuPath = entity.MenuPath,
            Icon = entity.Icon,
            PermissionKey = entity.PermissionKey,
            ComponentPath = entity.ComponentPath,
            RouteName = entity.RouteName,
            ExternalLink = entity.ExternalLink,
            Remark = entity.Remark,
            Order = entity.Order,
            IsStatus = entity.IsStatus,
            IsVisible = entity.IsVisible
        };
    }
}

