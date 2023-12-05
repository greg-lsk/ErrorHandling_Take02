using ErrorHandling;
using ErrorHandling.Rule;
using ErrorHandling.Predicates;
using ConsoleApp.Core.ValueTypes;


namespace ConsoleApp.Core.Rules;

public static class NameRule
{

    public readonly static DomainRule IsNotNull = RuleBuilder.Create
    (
        predicate: (Name n) => GenericPredicates.IsNotNull(n),

        incomplianceTag:      NameTags.NullReference,
        incomplianceSeverity: IncomplianceSeverity.Error
    );


    public readonly static DomainRule WithinLength = RuleBuilder.Create
    (
        predicate: (string s) => StringPredicates.WithinLength(s, Name.MaxLength),

        incomplianceTag:      StringTags.LengthExceeded,
        incomplianceSeverity: IncomplianceSeverity.Error
    );


    public readonly static DomainRule HasValidStringFormat = RuleBuilder.Create
    (
        selector: (Name n) => n.StringValue,
        sequence: NameRuleSequence.ForStringFormat,

        incomplianceTag:      NameTags.InvalidStringFormat,
        incomplianceSeverity: IncomplianceSeverity.Error
    );


    public readonly static DomainRule IsValid = RuleBuilder.Create
    (
        sequence: NameRuleSequence.ForValidName,

        incomplianceTag:      NameTags.InvalidName,
        incomplianceSeverity: IncomplianceSeverity.Error
    );

}