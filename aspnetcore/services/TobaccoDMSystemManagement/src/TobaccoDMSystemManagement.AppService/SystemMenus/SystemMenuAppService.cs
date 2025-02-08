using TobaccoDMSystemManagement.AppService.SystemMenus.Dtos;
using TobaccoDMSystemManagement.Domain.SystemMenus;
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
    
    /// <summary>
    /// 创建菜单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<bool> CreateSystemMenuAsync(CreateSystemMenuInputDto input);
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
            ParentId = entity.ParentId,
            MenuPath = entity.MenuPath,
            Icon = entity.Icon,
            PermissionKey = entity.PermissionKey,
            ComponentPath = entity.ComponentPath,
            RouteName = entity.RouteName,
            ExternalLink = entity.ExternalLink,
            Remark = entity.Remark,
            OrderIndex = entity.OrderIndex,
            IsStatus = entity.IsStatus,
        };
    }

    /// <inheritdoc />
    public Task<bool> CreateSystemMenuAsync(CreateSystemMenuInputDto input)
    {
        // // 插入一组
        var systemMenu = CreateSystemMenu(input, null);

        // 插入会出问题： ORM 【SqlSugar】
        // 1、systemMenu SubMenus 会有问题, 提示没有这个字段
        // 2、只保存了父级菜单, 子菜单没有保存
        return systemMenuRepository.InsertAsync(systemMenu);
    }

    /// <summary>
    /// 递归创建菜单
    /// </summary>
    /// <param name="input"></param>
    /// <param name="parent"></param>
    private SystemMenu CreateSystemMenu(CreateSystemMenuInputDto input, SystemMenu? parent)
    {
        var systemMenu = new SystemMenu(
            GuidGenerator.Create(),
            input.MenuName,
            input.MenuPath,
            input.Icon,
            input.PermissionKey,
            input.RouteName,
            input.ComponentPath,
            input.OrderIndex);
        
        if (parent != null)
        {
            systemMenu.ChangeParentMenuId(parent.Id);
        }

        if (input.Childrens.Length > 0)
        {
            foreach (var child in input.Childrens)
            {
               var subSystemMenu = CreateSystemMenu(child, systemMenu);
               systemMenu.AddSubMenu(subSystemMenu);
            }
        }

        return systemMenu;
    }
    
    
}

