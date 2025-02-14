using TobaccoDMSystemManagement.AppService.SystemLogs.Dtos;
using TobaccoDMSystemManagement.Domain.SystemLogs;

namespace TobaccoDMSystemManagement.AppService.SystemLogs;

public interface ISystemLogAppService: ITobaccoDMSystemManagementAppService
{
    /// <summary>
    /// 创建：系统日志
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<bool> CreateAsync(CreateSystemLogInputDto input);
}

public class SystemLogAppService(ISystemLogRepository systemLogRepository) : TobaccoDMSystemManagementAppService, ISystemLogAppService
{
    /// <inheritdoc />
    public async Task<bool> CreateAsync(CreateSystemLogInputDto input)
    {
        var systemLog = new SystemLog(GuidGenerator.Create(), input.ApplicationName, input.ApplicationId, input.LogContent);
        var result = await systemLogRepository.InsertAsync(systemLog);
        return result!= null;
    }
}
