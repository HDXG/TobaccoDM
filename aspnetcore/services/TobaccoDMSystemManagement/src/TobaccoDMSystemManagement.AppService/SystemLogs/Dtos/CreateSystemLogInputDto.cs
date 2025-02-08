namespace TobaccoDMSystemManagement.AppService.SystemLogs.Dtos;

public class CreateSystemLogInputDto
{
    /// <summary>
    /// 应用名称
    /// </summary>
    public string ApplicationName { get; set; }

    /// <summary>
    /// 应用Id
    /// </summary>
    public string ApplicationId { get; set; }
    
    /// <summary>
    /// 日志内容
    /// </summary>
    public string LogContent { get; set; }
}