using ErrorHandling;
using ErrorHandling.Evaluating;


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
        IncomplianceDelegate.StringIsEmpty,
        InvalidNameFlags.NameStringValueIsEmpty,
        IncomplianceSeverity.Fatal
    );

    public static readonly IncomplianceRecord<string> NameStartsWithLowerCase = new
    (
        IncomplianceDelegate.StringStartsWithLowerCase,
        InvalidNameFlags.NameStringValueStartsWithLowerCaseChar,
        IncomplianceSeverity.Error
    );

    public static readonly IncomplianceRecord<string, int> NameExceedsLength = new
    (
        IncomplianceDelegate.StringExceedsLength,
        InvalidNameFlags.NameStringValueMaxLengthExceeded,
        IncomplianceSeverity.Error
    );
}

public static partial class EvaluationChain
{
    public static void InvalidName(Evaluator<string> evaluator) => 
        evaluator.Examine(in Incompliance.NameIsEmpty)
                 .Examine(in Incompliance.NameStartsWithLowerCase)
                 .Examine(in Incompliance.NameExceedsLength, Name.MaxLength);
}