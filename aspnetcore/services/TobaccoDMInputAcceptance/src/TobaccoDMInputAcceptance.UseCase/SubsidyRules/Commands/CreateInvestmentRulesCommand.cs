using Dedsi.Ddd.CQRS.Commands;

namespace TobaccoDMInputAcceptance.SubsidyRules.Commands;

public record CreateInvestmentRulesCommand : DedsiCommand<bool>;

