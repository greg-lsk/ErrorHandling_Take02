using ErrorHandling.Evaluating;
using ErrorHandling.ResultUtilities;

namespace ConsoleApp.ValueTypes;

public readonly struct Name
{
    public const int MaxLength = 4;
    public readonly string StringValue; 


    internal Name(string stringValue) => StringValue = stringValue;


    public static Result<Name> Create(string stringValue)
    {
        var evaluation = Evaluation.Init<Name>();

        evaluation.Evaluate(stringValue)
                  .CaptureAll()
                    .Examine(in Incompliance.NameIsEmpty)
                    .Examine(in Incompliance.NameStartsWithLowerCase)
                    .Examine(in Incompliance.NameExceedsLength, MaxLength);

        return evaluation.YieldResult(stringValue, (sv) => new Name(sv));
    }

    public static VoidResult Change<TSelectedFrom>(StructSelector<TSelectedFrom, Name> selector,
                                                   TSelectedFrom selectedFrom, 
                                                   string? stringValue)
    {
        var evaluation = Evaluation.Init<Name>();

        evaluation.Evaluate(stringValue)
          .CaptureAll()
            .Examine(in Incompliance.NameIsEmpty)
            .Examine(in Incompliance.NameStartsWithLowerCase)
            .Examine(in Incompliance.NameExceedsLength, MaxLength);

        return evaluation.YieldVoid(selector,
                                    selectedFrom,
                                    stringValue,
                                    (s, sf, sv) => s.Invoke(sf) = new Name(sv!));
    }
}