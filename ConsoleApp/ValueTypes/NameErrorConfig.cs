using ErrorHandling;
using ErrorHandling.Evaluating;
using ErrorHandling.Predicates;

namespace ConsoleApp.ValueTypes;

public enum InvalidNameFlags
{
    NameStringValueIsEmpty,
    NameStringValueMaxLengthExceeded,
    NameStringValueStartsWithLowerCaseChar
}

public partial class Incompliance
{
    public static readonly IncomplianceRecord<string> NameIsEmpty = new
    (
        StringPredicates.IsEmpty,
        InvalidNameFlags.NameStringValueIsEmpty,
        IncomplianceSeverity.Fatal
    );

    public static readonly IncomplianceRecord<string> NameStartsWithLowerCase = new
    (
        StringPredicates.StartsWithLowerCase,
        InvalidNameFlags.NameStringValueStartsWithLowerCaseChar,
        IncomplianceSeverity.Error
    );

    public static readonly IncomplianceRecord<string, int> NameExceedsLength = new
    (
        StringPredicates.ExceedsLength,
        InvalidNameFlags.NameStringValueMaxLengthExceeded,
        IncomplianceSeverity.Error
    );
}


public static partial class IncomplianceChain
{
    public static void InvalidName(Evaluator<string> evaluator) => 
        evaluator.Examine(in Incompliance.NameIsEmpty)
                 .Examine(in Incompliance.NameStartsWithLowerCase)
                 .Examine(in Incompliance.NameExceedsLength, Name.MaxLength);
}