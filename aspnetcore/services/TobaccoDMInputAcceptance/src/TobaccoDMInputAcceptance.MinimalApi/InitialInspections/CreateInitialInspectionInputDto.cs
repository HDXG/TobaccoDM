namespace TobaccoDMInputAcceptance.InitialInspections;

public record CreateInitialInspectionInputDto(string InitialName, string InitialDescription, InitialInspectorInputDto InitialInspector, TobaccoGrowersInputDto[] TobaccoGrowers);

/// <summary>
/// 初验员
/// </summary>
/// <param name="UserId"></param>
/// <param name="UserName"></param>
/// <param name="DeptId"></param>
public record InitialInspectorInputDto(Guid UserId, string UserName, string DeptId);

/// <summary>
/// 验收的烟农
/// </summary>
/// <param name="Name"></param>
/// <param name="IdCard"></param>
/// <param name="ImplementationQuantity"></param>
public record TobaccoGrowersInputDto(string Name, string IdCard, decimal ImplementationQuantity);