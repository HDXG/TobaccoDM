using Dedsi.Ddd.CQRS.Commands;

namespace TobaccoDMInputAcceptance.InitialInspections.Commands;

/// <summary>
/// 创建 投入验收 命令
/// </summary>
/// <param name="InitialName"></param>
/// <param name="InitialDescription"></param>
/// <param name="InitialInspector"></param>
/// <param name="TobaccoGrowers"></param>
public record CreateInitialInspectionCommand(string InitialName,string InitialDescription,InitialInspector InitialInspector,TobaccoGrower[] TobaccoGrowers) : DedsiCommand<bool>;