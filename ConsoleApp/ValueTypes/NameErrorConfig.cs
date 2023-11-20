using ErrorHandling;
using ErrorHandling.Evaluating;
using ErrorHandling.Predicates;
using ErrorHandling.Rule;

namespace ConsoleApp.ValueTypes;

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
        (StringPredicates.IsEmpty, 
        InvalidNameTags.IsEmpty, 
        IncomplianceSeverity.Error,
        enablesShortCircuiting: true),

        (StringPredicates.StartsWithLowerCase, 
        InvalidNameTags.StartsWithLowerCase, 
        IncomplianceSeverity.Error,
        enablesShortCircuiting: false),

        (s => StringPredicates.ExceedsLength(s, Name.MaxLength), 
        InvalidNameTags.LengthExceeded, 
        IncomplianceSeverity.Error,
        enablesShortCircuiting: false)
    );

    public static void InvalidName(Evaluator<string> evaluator) => 
        evaluator.Examine(in Incompliance.NameIsEmpty)
                 .Examine(in Incompliance.NameStartsWithLowerCase)
                 .Examine(in Incompliance.NameExceedsLength, Name.MaxLength);
}