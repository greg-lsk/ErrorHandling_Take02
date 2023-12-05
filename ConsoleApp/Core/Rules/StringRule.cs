using ErrorHandling;
using ErrorHandling.Rule;
using ErrorHandling.Predicates;


namespace ConsoleApp.Core.Rules;

public static class StringRule
{
    public static readonly DomainRule IsNotEmpty = RuleBuilder.Create<string>
    (
        predicate: StringPredicates.IsNotEmpty,

        incomplianceTag:      StringTags.IsEmpty,
        incomplianceSeverity: IncomplianceSeverity.Error
    );

    public static readonly DomainRule StartsWithUpperCase = RuleBuilder.Create<string>
    (
        predicate: StringPredicates.StartsWithUpperCase,

        incomplianceTag:      StringTags.StartsWithLowerCase,
        incomplianceSeverity: IncomplianceSeverity.Error
    );
}