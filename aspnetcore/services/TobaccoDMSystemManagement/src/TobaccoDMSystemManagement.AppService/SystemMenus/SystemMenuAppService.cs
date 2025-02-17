using TobaccoDMSystemManagement.AppService.SystemMenus.Dtos;
using TobaccoDMSystemManagement.Domain.SystemMenus;
using Volo.Abp.Domain.Repositories;

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
        var entity = await systemMenuRepository.GetListIncludeAsync(x=>x.IsStatus,x=>x.SubMenus);
        var entityPart = entity.Where(x => x.ParentId == null).ToList();
        if (entity.Count > 0 && entityPart.Count > 0)
        {
            List<SystemMenuDto> systemMenuDtos = new List<SystemMenuDto>();
            foreach (var systemMenu in entityPart)
            {
                systemMenuDtos.Add(SystemMenuSumMenusList(systemMenu));
            }
            return systemMenuDtos;
        }
        return new List<SystemMenuDto>();
    }



    public async Task<SystemMenuDto> GetSystemMenuAsync(Guid id)
    {
        var entity = await systemMenuRepository.GetIncludeAsync(x => x.Id == id, x => x.SubMenus);
        if (entity != null)
        {
            SystemMenuDto sysMenuDto = SystemMenuSumMenusList(entity);
            return sysMenuDto;
        }
        else
        {
            return new SystemMenuDto();
        }
    }

    private SystemMenuDto SystemMenuSumMenusList(SystemMenu entity)
    {
        var sysMenuDto = new SystemMenuDto()
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
            IsStatus = entity.IsStatus
        };
        if (entity.SubMenus.Count > 0)
        {
            List<SystemMenuDto> systemMenuDtos = new List<SystemMenuDto>();
            foreach (var item in entity.SubMenus)
            {
                systemMenuDtos.Add(SystemMenuSumMenusList(item));
            }
            sysMenuDto.SubMenus = systemMenuDtos;
        }
        return sysMenuDto;
    }


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

    /// <summary>
    /// 删除方法
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<bool> DeleteSystemMenuAsync(Guid id)
    {
        return await systemMenuRepository.DeleteAsync(await systemMenuRepository.GetIncludeAsync(x=>x.Id==id,x=>x.SubMenus));
    }
}

