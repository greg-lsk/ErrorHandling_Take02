using ErrorHandling.Evaluation;

namespace ConsoleApp.ValueTypes;

public struct Name
{
    public const int MaxLength = 4;
    public string StringValue { get; set; }

    public static void Test(string stringValue)
    {
        var evaluation = Evaluation.Init();

        evaluation.Evaluate(stringValue)
                  .CaptureAll()
                    .Examine(in Incompliance.NameIsEmpty)
                    .Examine(in Incompliance.NameStartsWithLowerCase)
                    .Examine(in Incompliance.NameExceedsLength, MaxLength)
                  .Snooze();

        //Do other stuff here

        evaluation.Print();
    }
}