using System.DirectoryServices.ActiveDirectory;
using SqlSugar;
using Volo.Abp.Domain.Entities;
using Check = Volo.Abp.Check;

namespace TobaccoDMSystemManagement.Domain.SystemMenus;

/// <summary>
/// 系统菜单
/// </summary>
public class SystemMenu : Entity<Guid>
{
    public SystemMenu() { }

    /// <summary>
    /// 系统菜单
    /// </summary>
    /// <param name="id"></param>
    /// <param name="menuName"></param>
    /// <param name="menuPath"></param>
    /// <param name="icon"></param>
    /// <param name="permissionKey"></param>
    /// <param name="routeName"></param>
    /// <param name="componentPath"></param>
    /// <param name="orderIndex"></param>
    public SystemMenu(Guid id,string menuName, string menuPath, string icon, string permissionKey, string routeName, string componentPath,int orderIndex): base(id)
    {
        SetExternalLinkToFalse();
        SetStatusToTrue();
        
        ChangeMenuName(menuName);
        ChangeMenuPath(menuPath);
        ChangeIcon(icon);
        ChangePermissionKey(permissionKey);
        ChangeComponentPath(componentPath);
        ChangeRouteName(routeName);
        ChangeOrderIndex(orderIndex);
    }

    /// <summary>
    /// 菜单/按钮 名称
    /// </summary>
    public string MenuName { get; private set; }

    public void ChangeMenuName(string newMenuName)
    {
        MenuName = Check.NotNullOrWhiteSpace(newMenuName, "MenuName");
    }

    /// <summary>
    /// 父级ID
    /// </summary>
    public Guid? ParentId { get; private set; }

    public void ChangeParentMenuId(Guid? newParentId)
    {
        ParentId = newParentId;
    }

    /// <summary>
    ///  菜单路径
    /// </summary>
    public string MenuPath { get; private set; }

    public void ChangeMenuPath(string newMenuPath)
    {
        MenuPath = Check.NotNullOrWhiteSpace(newMenuPath, "MenuPath");
    }

    /// <summary>
    ///   图标
    /// </summary>
    public string Icon { get; private set; }

    public void ChangeIcon(string newIcon)
    {
        Icon = Check.NotNullOrWhiteSpace(newIcon, "Icon");
    }

    /// <summary>
    ///  权限标识
    /// </summary>
    public string PermissionKey { get; private set; }

    public void ChangePermissionKey(string newPermissionKey)
    {
        PermissionKey = Check.NotNullOrWhiteSpace(newPermissionKey, "PermissionKey");
    }

    /// <summary>
    /// 组件路径
    /// </summary>
    public string ComponentPath { get; private set; }

    public void ChangeComponentPath(string newComponentPath)
    {
        ComponentPath = Check.NotNullOrWhiteSpace(newComponentPath, "ComponentPath");
    }

    /// <summary>
    ///  路由名称
    /// </summary>
    public string RouteName { get; private set; }

    public void ChangeRouteName(string newRouteName)
    {
        RouteName = Check.NotNullOrWhiteSpace(newRouteName, "RouteName");
    }

    /// <summary>
    /// 是否外链
    /// </summary>
    public bool ExternalLink { get; private set; }

    public void SetExternalLinkToTrue()
    {
        ExternalLink = true;
    }

    public void SetExternalLinkToFalse()
    {
        ExternalLink = false;
    }
    
    /// <summary>
    /// 排序
    /// </summary>
    public int OrderIndex { get; private set; }

    public void ChangeOrderIndex(int newOrderIndex)
    {
        OrderIndex = newOrderIndex;
    }

    /// <summary>
    /// 备注描述或者说明
    /// </summary>
    public string? Remark { get; private set; }

    public void ChangeRemark(string newRemark)
    {
        Remark = Check.NotNullOrWhiteSpace(newRemark, "Remark");
    }

    /// <summary>
    /// 状态  启用/禁用
    /// </summary>
    public bool IsStatus { get; private set; }

    public void SetStatusToTrue()
    {
        IsStatus = true;
    }

    public void SetStatusToFalse()
    {
        IsStatus = false;
    }


    public ICollection<SystemMenu> SubMenus { get; protected set; } = new List<SystemMenu>();


    public void AddSubMenu(SystemMenu systemMenu)
    {
        systemMenu.ChangeParentMenuId(Id);
        SubMenus.Add(systemMenu);
    }

    public void ClearSubMenus()
    {
        SubMenus.Clear();
    }
    
}

