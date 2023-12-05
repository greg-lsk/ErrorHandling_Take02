namespace ConsoleApp.Core.ValueTypes;

public readonly struct Name
{
    public const int MaxLength = 4;
    internal readonly string StringValue;


    internal Name(string stringValue) => StringValue = stringValue;
}