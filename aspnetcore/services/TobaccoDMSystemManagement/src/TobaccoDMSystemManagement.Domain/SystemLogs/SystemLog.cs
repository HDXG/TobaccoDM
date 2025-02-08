namespace TobaccoDMSystemManagement.Domain.SystemLogs;

/// <summary>
/// 系统日志
/// </summary>
public class SystemLog : Entity<Guid>
{
    /// <summary>
    /// Ef Core 要求必须有一个无参数的构造函数
    /// </summary>
    protected SystemLog()
    {
    }

    /// <summary>
    /// 创建一个新的系统日志
    /// </summary>
    /// <param name="id"></param>
    /// <param name="applicationName"></param>
    /// <param name="applicationId"></param>
    /// <param name="logContent"></param>
    public SystemLog(Guid id, string applicationName, string applicationId, string logContent) : base(id)
    {
        CreateTime = DateTime.Now;

        ApplicationName = applicationName;
        ApplicationId = applicationId;
        LogContent = logContent;
    }
    
    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreateTime { get; private set; }

    /// <summary>
    /// 应用名称
    /// </summary>
    public string ApplicationName { get; private set; }

    /// <summary>
    /// 应用Id
    /// </summary>
    public string ApplicationId { get; private set; }
    
    /// <summary>
    /// 日志内容
    /// </summary>
    public string LogContent { get; private set; }
    

}