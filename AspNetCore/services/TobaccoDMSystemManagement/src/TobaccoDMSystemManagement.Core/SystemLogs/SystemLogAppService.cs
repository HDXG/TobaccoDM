using TobaccoDMSystemManagement.Infrastructure.Repositories.SystemLogs;

namespace TobaccoDMSystemManagement.Core.SystemLogs;

public interface ISystemLogAppService: ITobaccoDMSystemManagementAppService;

public class SystemLogAppService(ISystemLogRepository systemLogRepository) : TobaccoDMSystemManagementAppService, ISystemLogAppService;