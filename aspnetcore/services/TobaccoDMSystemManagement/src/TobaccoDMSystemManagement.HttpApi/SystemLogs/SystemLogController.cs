using Microsoft.AspNetCore.Mvc;
using TobaccoDMSystemManagement.AppService.SystemLogs;
using TobaccoDMSystemManagement.AppService.SystemLogs.Dtos;

namespace TobaccoDMSystemManagement.SystemLogs;

/// <summary>
/// 系统日志
/// </summary>
/// <param name="systemLogAppService"></param>
public class SystemLogController(ISystemLogAppService systemLogAppService) : TobaccoDMSystemManagementController
{
    /// <summary>
    /// 创建：系统日志
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public Task<bool> CreateAsync(CreateSystemLogInputDto input)
    {
        return systemLogAppService.CreateAsync(input);
    }
}