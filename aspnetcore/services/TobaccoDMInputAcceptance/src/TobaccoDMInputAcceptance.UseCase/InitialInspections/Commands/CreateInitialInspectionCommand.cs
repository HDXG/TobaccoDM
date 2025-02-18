using Dedsi.Ddd.CQRS.Commands;
using TobaccoDMInputAcceptance.InitialInspections.Dtos;

namespace TobaccoDMInputAcceptance.InitialInspections.Commands;

public record CreateInitialInspectionCommand(string initialName,string initialDescription, InitialInspectorInputDto InitialInspectorInputDto, TobaccoGrowersInputDto[] TobaccoGrowers ) : DedsiCommand<bool>;



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
/// <param name="initialInspectionId"></param>
/// <param name="name"></param>
/// <param name="idCard"></param>
/// <param name="implementationQuantity"></param>
public record TobaccoGrowersInputDto(Guid initialInspectionId, string name, string idCard, decimal implementationQuantity);