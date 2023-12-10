namespace ConsoleApp.Core.ValueTypes;

public readonly struct Name
{
    public const int MaxLength = 4;
    private readonly string _stringValue;

    public int Length => _stringValue.Length;
    public bool IsEmpty => _stringValue == string.Empty;
    public bool StartsWithUpperCase => char.IsUpper(_stringValue[0]);


    internal Name(string stringValue) => _stringValue = stringValue;


    public override readonly string ToString() => _stringValue;
}