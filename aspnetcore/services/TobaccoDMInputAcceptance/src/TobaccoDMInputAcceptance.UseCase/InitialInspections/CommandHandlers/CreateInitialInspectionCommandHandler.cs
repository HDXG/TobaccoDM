using Dedsi.Ddd.CQRS.CommandHandlers;
using TobaccoDMInputAcceptance.Repositories.InitialInspections;
using TobaccoDMInputAcceptance.InitialInspections.Commands;

namespace TobaccoDMInputAcceptance.InitialInspections.CommandHandlers;

public class CreateInitialInspectionCommandHandler(IInitialInspectionRepository inspectionRepository) : DedsiCommandHandler<CreateInitialInspectionCommand, bool>
{
    public override async Task<bool> Handle(CreateInitialInspectionCommand command, CancellationToken cancellationToken)
    {
        //初验员
        var initialInspector =new InitialInspector(command.InitialInspectorInputDto.UserId, command.InitialInspectorInputDto.UserName, command.InitialInspectorInputDto.DeptId);

        var initialInspection = new InitialInspection(GuidGenerator.Create(), command.initialName, command.initialDescription, initialInspector);

        //验收的烟农
        foreach (var tobaccoGrower in command.TobaccoGrowers)
        {
            TobaccoGrower tobacco = new TobaccoGrower(GuidGenerator.Create(), initialInspection.Id, tobaccoGrower.name, tobaccoGrower.idCard, tobaccoGrower.implementationQuantity);
            tobacco.ChangeInitialInspectionQuantity(0);
            initialInspection.AddTobaccoGrower(tobacco);
        }

        await inspectionRepository.InsertAsync(initialInspection,false, cancellationToken);
        return true;
    }
}