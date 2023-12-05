using ErrorHandling;
using ErrorHandling.Rule;
using ErrorHandling.Predicates;
using ConsoleApp.Core.ValueTypes;


namespace ConsoleApp.Core.Rules;

public static class NameRule
{
    public readonly static DomainRule WithinLength = RuleBuilder.Create
    (
        predicate: (string s) => StringPredicates.WithinLength(s, Name.MaxLength),

        incomplianceTag:      StringTags.LengthExceeded,
        incomplianceSeverity: IncomplianceSeverity.Error
    );

    public readonly static DomainRule ValidStringFormat = RuleBuilder.Create
    (
        selector: (Name n) => n.StringValue,
        sequence: NameRuleSequence.StringFormat,

        incomplianceTag:      NameTags.InvalidStringFormat,
        incomplianceSeverity: IncomplianceSeverity.Error
    );
}