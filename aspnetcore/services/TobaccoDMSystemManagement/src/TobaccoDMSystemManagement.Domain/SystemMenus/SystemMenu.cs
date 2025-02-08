namespace TobaccoDMSystemManagement.Domain.SystemMenus
{
    public class SystemMenu : Entity<Guid>
    {
        public SystemMenu() { }

        public SystemMenu(string menuName, string parentMenuID, string menuPath, string icon, string permissionKey, bool? externalLink, string remark, int menuType, string routeName, string componentPath, int order)
        {
            MenuName = menuName;
            ParentMenuID = parentMenuID;
            MenuType = menuType;
            MenuPath = menuPath;
            RouteName = routeName;
            Icon = icon;
            PermissionKey = permissionKey;
            ComponentPath = componentPath;
            ExternalLink = externalLink;
            Remark = remark;
            Order = order;
        }

        /// <summary>
        /// 菜单/按钮 名称
        /// </summary>
        public string MenuName { get; private set; }


        /// <summary>
        /// 父级ID
        /// </summary>
        public string ParentMenuID { get; private set; }

        /// <summary>
        /// 菜单类型  0目录/1菜单/2按钮
        /// </summary>
        public int MenuType { get; private set; }

        /// <summary>
        ///  菜单路径
        /// </summary>
        public string MenuPath { get; private set; }

        /// <summary>
        ///   图标
        /// </summary>
        public string Icon { get; private set; }

        /// <summary>
        ///  权限标识
        /// </summary>
        public string PermissionKey { get; private set; }

        /// <summary>
        ///   组件路径
        /// </summary>
        public string ComponentPath { get; private set; }

        /// <summary>
        ///  路由名称
        /// </summary>
        public string RouteName { get; private set; }

        /// <summary>
        ///   是否外链
        /// </summary>
        public bool? ExternalLink { get; private set; }

        /// <summary>
        ///   备注描述或者说明
        /// </summary>
        public string Remark { get; private set; }

        /// <summary>
        ///  菜单/按钮状态  启用/禁用
        /// </summary>
        public bool IsStatus { get; private set; }


        /// <summary>
        ///   是否可见
        /// </summary>
        public bool IsVisible { get; private set; }

        public int Order { get; private set; }
        public DateTime CreateTime { get; private set; }
        public DateTime UpdateTime { get; private set; }


        public void CreateIdTime(Guid iGuid)
        {
            this.CreateTime = DateTime.Now;
            this.Id = iGuid;
        }
       
        public void SavaUpdateTime()
        {
            this.UpdateTime = DateTime.Now;
        }
    }
}
