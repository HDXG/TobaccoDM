using Microsoft.AspNetCore.Mvc;
using TobaccoDMSystemManagement.AppService.SystemMenus;
using TobaccoDMSystemManagement.AppService.SystemMenus.Dtos;

namespace TobaccoDMSystemManagement.SystemMenus;

/// <summary>
/// 系统添加菜单
/// </summary>
public class SystemMenuController(ISystemMenuAppService systemMenuAppService):TobaccoDMSystemManagementController
{

    /// <summary>
    /// 获取单个菜单信息
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public Task<SystemMenuDto> GetSystemMenuAsync(Guid id) => systemMenuAppService.GetSystemMenuAsync(id);

}