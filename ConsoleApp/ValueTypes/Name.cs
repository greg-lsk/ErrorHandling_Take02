using ErrorHandling.Evaluating;
using ErrorHandling.ResultUtilities;


namespace ConsoleApp.ValueTypes;

public readonly struct Name
{
    public const int MaxLength = 4;
    public readonly string StringValue; 


    internal Name(string stringValue) => StringValue = stringValue;
}