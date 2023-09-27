using ErrorHandling;
using ErrorHandling.Evaluating;

namespace ConsoleApp.ValueTypes;

public struct Name
{
    public const int MaxLength = 4;
    public string StringValue { get; set; }

    public static Result<Name> Create(string stringValue)
    {
        var evaluation = Evaluation.Init();

        return evaluation
            .Evaluate(stringValue)
            .CaptureAll()
                .Examine(in Incompliance.NameIsEmpty)
                .Examine(in Incompliance.NameStartsWithLowerCase)
                .Examine(in Incompliance.NameExceedsLength, MaxLength)
            .YieldResult<Name>(() => new() { StringValue = stringValue });
    }
}