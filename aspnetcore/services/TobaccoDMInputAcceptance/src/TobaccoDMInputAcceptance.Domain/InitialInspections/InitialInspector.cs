namespace TobaccoDMInputAcceptance.InitialInspections;

/// <summary>
/// 初验员
/// </summary>
/// <param name="UserId"></param>
/// <param name="UserName"></param>
/// <param name="DeptId"></param>
public record InitialInspector(Guid UserId, string UserName, string DeptId);