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

    internal readonly Span<char> SpanView
    {
        get
        {
            var addition = FlagPrefix.SpanView;
            var severity = SeverityView.GetSpan(_severity);
            var flagText = _errorFlag.ToString().AsSpan();//alloc

            Span<char> flagInfoBuffer = new char[addition.Length + severity.Length + flagText.Length];//array pooling?

            addition.CopyTo(flagInfoBuffer);
            severity.CopyTo(flagInfoBuffer[addition.Length..]);
            flagText.CopyTo(flagInfoBuffer[(severity.Length + addition.Length)..]);

            return flagInfoBuffer;
        }
    }

    internal readonly Memory<char> MemoryView
    {
        get
        {
            var addition = FlagPrefix.MemoryView;
            var severity = SeverityView.GetMemory(_severity);
            var flagText = _errorFlag.ToString().AsMemory();//alloc

            Memory<char> flagInfoBuffer = new char[addition.Length + severity.Length + flagText.Length]; //array pooling?

            addition.CopyTo(flagInfoBuffer);
            severity.CopyTo(flagInfoBuffer[addition.Length..]);
            flagText.CopyTo(flagInfoBuffer[(severity.Length + addition.Length)..]);
            return flagInfoBuffer;
        }
    }
}


internal static class SeverityView
{
    private static readonly char[] _alert = new[] { ' ', '|', '-', '[', 'a', 'l', 'e', 'r', 't', ']', ':'  };
    private static readonly char[] _error = new[] { ' ', '|', '-', '[', 'e', 'r', 'r', 'o', 'r', ']', ':' };
    private static readonly char[] _fatal = new[] { ' ', '|', '-', '[', 'f', 'a', 't', 'a', 'l', ']', ':' };

    internal static ReadOnlySpan<char> GetSpan(IncomplianceSeverity severity) => severity switch 
    {
        IncomplianceSeverity.Alert => _alert.AsSpan(),
        IncomplianceSeverity.Error => _error.AsSpan(),
        IncomplianceSeverity.Fatal => _fatal.AsSpan()
    };

    internal static ReadOnlyMemory<char> GetMemory(IncomplianceSeverity severity) => severity switch
    {
        IncomplianceSeverity.Alert => _alert.AsMemory(),
        IncomplianceSeverity.Error => _error.AsMemory(),
        IncomplianceSeverity.Fatal => _fatal.AsMemory()
    };
}

public static class FlagPrefix
{
    public static int loggerProviderIndent;
    private static char[]? _flagInfoPrefix;

    internal static int Length => loggerProviderIndent + 1;

    public static void Create()
    {
        _flagInfoPrefix = new char[loggerProviderIndent + 1];

        _flagInfoPrefix[0] = '\n';
        for (int i = 1; i < _flagInfoPrefix.Length; ++i)
            _flagInfoPrefix[i] = ' ';

    }

    internal static ReadOnlySpan<char> SpanView => _flagInfoPrefix.AsSpan();
    internal static ReadOnlyMemory<char> MemoryView => _flagInfoPrefix.AsMemory();
}