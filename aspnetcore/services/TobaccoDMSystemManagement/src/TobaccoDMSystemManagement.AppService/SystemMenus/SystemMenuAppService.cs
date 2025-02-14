using TobaccoDMSystemManagement.AppService.SystemMenus.Dtos;
using TobaccoDMSystemManagement.Domain.SystemMenus;

namespace TobaccoDMSystemManagement.AppService.SystemMenus;

public interface ISystemMenuAppService : ITobaccoDMSystemManagementAppService
{
    /// <summary>
    /// 单个菜单信息以及 下属集合
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
    

    /// <summary>
    /// 删除菜单
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    
    Task<bool> DeleteSystemMenuAsync(Guid id);


    /// <summary>
    /// 获取菜单列表
    /// </summary>
    /// <returns></returns>
    Task<List<SystemMenuDto>> GetSystemMenuListAsync();
}

public class SystemMenuAppService(ISystemMenuRepository systemMenuRepository) : TobaccoDMSystemManagementAppService, ISystemMenuAppService
{
    public async Task<List<SystemMenuDto>> GetSystemMenuListAsync()
    {
        var entity = await systemMenuRepository.GetListAsync();
        var entityPart = entity.Where(x => x.ParentId == null).ToList();
        if (entity.Count > 0 && entityPart.Count > 0)
        {
            List<SystemMenuDto> systemMenuDtos = new List<SystemMenuDto>();
            foreach (var systemMenu in entityPart)
            {

                systemMenuDtos.Add(SystemMenuSumMenusList(entity, systemMenu));
            }
            return systemMenuDtos;
        }
        return new List<SystemMenuDto>();
    }



    public async Task<SystemMenuDto> GetSystemMenuAsync(Guid id)
    {
        var entity = await systemMenuRepository.GetListAsync();
        if (entity.Count(x => x.Id == id) > 0)
        {
            var systemMenu = entity.First(x => x.Id == id);
            SystemMenuDto sysMenuDto = SystemMenuSumMenusList(entity, systemMenu);
            return sysMenuDto;
        }
        else
        {
            return new SystemMenuDto();
        }


    }

    private SystemMenuDto SystemMenuSumMenusList(List<SystemMenu> entity, SystemMenu systemMenu)
    {
        var sysMenuDto = new SystemMenuDto()
        {
            Id = systemMenu.Id,
            MenuName = systemMenu.MenuName,
            ParentId = systemMenu.ParentId,
            MenuPath = systemMenu.MenuPath,
            Icon = systemMenu.Icon,
            PermissionKey = systemMenu.PermissionKey,
            ComponentPath = systemMenu.ComponentPath,
            RouteName = systemMenu.RouteName,
            ExternalLink = systemMenu.ExternalLink,
            Remark = systemMenu.Remark,
            OrderIndex = systemMenu.OrderIndex,
            IsStatus = systemMenu.IsStatus
        };
        if (entity.Count(x => x.ParentId == systemMenu.Id) > 0)
        {
            sysMenuDto.SubMenus = getListSystemMenuDto(entity, systemMenu.Id);
        }

        return sysMenuDto;
    }

    private List<SystemMenuDto> getListSystemMenuDto(List<SystemMenu> entity, Guid parent)
    {
        List<SystemMenuDto> systemMenuDtos = new List<SystemMenuDto>();

        if (entity.Count(x => x.ParentId == parent) > 0)
        {
            foreach (SystemMenu systemMenu in entity.Where(x => x.ParentId == parent))
            {
                systemMenuDtos.Add(new SystemMenuDto()
                {
                    Id = systemMenu.Id,
                    MenuName = systemMenu.MenuName,
                    ParentId = systemMenu.ParentId,
                    MenuPath = systemMenu.MenuPath,
                    Icon = systemMenu.Icon,
                    PermissionKey = systemMenu.PermissionKey,
                    ComponentPath = systemMenu.ComponentPath,
                    RouteName = systemMenu.RouteName,
                    ExternalLink = systemMenu.ExternalLink,
                    Remark = systemMenu.Remark,
                    OrderIndex = systemMenu.OrderIndex,
                    IsStatus = systemMenu.IsStatus,
                    SubMenus = getListSystemMenuDto(entity, systemMenu.Id)
                });
            }
        }
        return systemMenuDtos;

    }

    /// <inheritdoc />
    public async Task<bool> CreateSystemMenuAsync(CreateSystemMenuInputDto input)
    {
        var   systemMenu = CreateSystemMenu(input, null);
        await systemMenuRepository.InsertAsync(systemMenu);
        return true;
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

    public async Task<bool> DeleteSystemMenuAsync(Guid id)
    {
        await systemMenuRepository.DeleteAsync(id);
        return true;
    }
}

