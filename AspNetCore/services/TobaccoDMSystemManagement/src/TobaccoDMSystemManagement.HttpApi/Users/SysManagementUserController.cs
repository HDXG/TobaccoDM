using Microsoft.AspNetCore.Mvc;
using TobaccoDMSystemManagement.Domain;

namespace TobaccoDMSystemManagement
{
    public class SysManagementUserController: TobaccoDMSystemManagementController
    {
        /// <summary>
        /// 测试使用
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string Demo()=>"测试成功";
    }
}
