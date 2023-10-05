namespace ErrorHandling.Reporting.CallStackInfo;


internal readonly struct FlagInfo
{
    private readonly Enum _errorFlag;
    private readonly IncomplianceSeverity _severity;


    internal FlagInfo(Enum errorFlag, IncomplianceSeverity severity)
    {
        _errorFlag = errorFlag;
        _severity = severity;
    }


    public override readonly string ToString() => $" |-[{_severity}]: {_errorFlag}";

    internal readonly string ErrorFlagPart()
    {
        var prefix = SeveritySpanView.Get(_severity);
        var suffix = _errorFlag.ToString().AsSpan();

        Span<char> flagInfoBuffer = new char[prefix.Length + suffix.Length];

        prefix.CopyTo(flagInfoBuffer);
        suffix.CopyTo(flagInfoBuffer[prefix.Length..]);

        return flagInfoBuffer.ToString();
    }

    internal readonly Span<char> SpanView
    {
        get
        {
            var prefix = SeveritySpanView.Get(_severity);
            var suffix = _errorFlag.ToString().AsSpan();

            Span<char> flagInfoBuffer = new char[prefix.Length + suffix.Length]; /*this can be avoided 
                                                                                   with array-pooling*/
            prefix.CopyTo(flagInfoBuffer);
            suffix.CopyTo(flagInfoBuffer[prefix.Length..]);

            return flagInfoBuffer;
        }
    }
}

internal static class SeveritySpanView
{
    private static readonly char[] _alert = new[] { '[', 'a', 'l', 'e', 'r', 't', ']', ':' };
    private static readonly char[] _error = new[] { '[', 'e', 'r', 'r', 'o', 'r', ']', ':' };
    private static readonly char[] _fatal = new[] { '[', 'f', 'a', 't', 'a', 'l', ']', ':' };

    internal static ReadOnlySpan<char> Get(IncomplianceSeverity severity) => severity switch 
    {
        IncomplianceSeverity.Alert => _alert.AsSpan(),
        IncomplianceSeverity.Error => _error.AsSpan(),
        IncomplianceSeverity.Fatal => _fatal.AsSpan()
    };
            
}