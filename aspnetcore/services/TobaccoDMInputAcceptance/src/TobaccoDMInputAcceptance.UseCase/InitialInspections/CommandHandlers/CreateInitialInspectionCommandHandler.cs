using Dedsi.Ddd.CQRS.CommandHandlers;
using TobaccoDMInputAcceptance.Repositories.InitialInspections;
using TobaccoDMInputAcceptance.InitialInspections.Commands;

namespace TobaccoDMInputAcceptance.InitialInspections.CommandHandlers;

public class CreateInitialInspectionCommandHandler(IInitialInspectionRepository inspectionRepository) : DedsiCommandHandler<CreateInitialInspectionCommand, bool>
{
    public override Task<bool> Handle(CreateInitialInspectionCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}