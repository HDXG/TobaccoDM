using Dedsi.Ddd.CQRS.CommandHandlers;
using TobaccoDMInputAcceptance.SubsidyRules.Commands;

namespace TobaccoDMInputAcceptance.SubsidyRules.CommandHandlers;

public class CreateInvestmentRulesCommandHandler : DedsiCommandHandler<CreateInvestmentRulesCommand, bool>
{
    public override async Task<bool> Handle(CreateInvestmentRulesCommand command, CancellationToken cancellationToken)
    {

        return true;
    }
}
