using Microsoft.AspNetCore.Mvc;
using TobaccoDMSystemManagement.AppService.SystemMenus;
using TobaccoDMSystemManagement.AppService.SystemMenus.Dtos;
namespace TobaccoDMSystemManagement.SystemMenus
{
    /// <summary>
    /// 系统添加菜单
    /// </summary>
    public class SystemMenuController(ISystemMenuAppService systemMenuAppService):TobaccoDMSystemManagementController
    {
        /// <summary>
        /// 保存菜单
        /// </summary>
        /// <param name="menuDto"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<bool> ChangeSystemMenu(SystemMenuDto menuDto) => systemMenuAppService.ChangeSystemMenu(menuDto);

        
        [HttpGet]
        public Task<SystemMenuDto> GetSystemMenu(Guid Id) => systemMenuAppService.GetSystemMenu(Id);

    }
}
