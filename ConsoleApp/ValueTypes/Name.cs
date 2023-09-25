using ErrorHandling.Evaluation;

namespace ConsoleApp.ValueTypes;

public struct Name
{
    public const int MaxLength = 4;
    public string StringValue { get; set; }

    public static void Test(string stringValue)
    {
        Evaluation.Init()
            .Evaluate(stringValue)
            .CaptureAll()
                .Examine(in Incompliance.NameIsEmpty)
                .Examine(in Incompliance.NameStartsWithLowerCase)
                .Examine(in Incompliance.NameExceedsLength, MaxLength)
        .YieldResult(stringValue);
    }
}