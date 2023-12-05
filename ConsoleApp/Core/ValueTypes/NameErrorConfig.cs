using ErrorHandling;
using ErrorHandling.Rule;
using ErrorHandling.Evaluating;
using ErrorHandling.Predicates;
using ConsoleApp.Core.Rules;


namespace ConsoleApp.Core.ValueTypes;

public enum InvalidNameTags
{
    IsEmpty,
    LengthExceeded,
    StartsWithLowerCase
}

public partial class Incompliance
{
    public static readonly IncomplianceRecord<string> NameIsEmpty = new
    (
        StringPredicates.IsEmpty,
        InvalidNameTags.IsEmpty,
        IncomplianceSeverity.Fatal
    );

    public static readonly IncomplianceRecord<string> NameStartsWithLowerCase = new
    (
        StringPredicates.StartsWithLowerCase,
        InvalidNameTags.StartsWithLowerCase,
        IncomplianceSeverity.Error
    );

    public static readonly IncomplianceRecord<string, int> NameExceedsLength = new
    (
        StringPredicates.ExceedsLength,
        InvalidNameTags.LengthExceeded,
        IncomplianceSeverity.Error
    );
}


public static partial class IncomplianceChain
{
    public static readonly RuleSequence<string> InvalidNameSeq = new
    (
        (StringRule.IsNotEmpty, enablesShortCircuiting: true),
        (NameRule.WithinLength, enablesShortCircuiting: false),
        (StringRule.StartsWithUpperCase, enablesShortCircuiting: false)
    );

    public static void InvalidName(Evaluator<string> evaluator) =>
        evaluator.Examine(in Incompliance.NameIsEmpty)
                 .Examine(in Incompliance.NameStartsWithLowerCase)
                 .Examine(in Incompliance.NameExceedsLength, Name.MaxLength);
}