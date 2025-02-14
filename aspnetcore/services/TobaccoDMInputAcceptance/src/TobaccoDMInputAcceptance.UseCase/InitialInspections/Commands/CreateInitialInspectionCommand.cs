using Dedsi.Ddd.CQRS.Commands;

namespace TobaccoDMInputAcceptance.InitialInspections.Commands;

public record CreateInitialInspectionCommand(): DedsiCommand<bool>;