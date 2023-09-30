﻿using ErrorHandling.Evaluating;
using ErrorHandling.Result;


namespace ConsoleApp.ValueTypes;

public readonly struct Name
{
    public const int MaxLength = 4;
    public readonly string StringValue; 

    internal Name(string stringValue) => StringValue = stringValue;

    public static Result<Name> Create(string stringValue)
    {
        var evaluation = Evaluation.Init();

        evaluation.Evaluate(stringValue)
                  .CaptureAll()
                    .Examine(in Incompliance.NameIsEmpty)
                    .Examine(in Incompliance.NameStartsWithLowerCase)
                    .Examine(in Incompliance.NameExceedsLength, MaxLength);

        return evaluation.YieldResultFull<Name>(() => new(stringValue));
    }
}