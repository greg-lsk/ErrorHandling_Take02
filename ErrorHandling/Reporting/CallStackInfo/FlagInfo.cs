using ErrorHandling.Reporting.Formatting;


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
            var severity = SeverityPrefix.GetSpan(_severity);
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
            var severity = SeverityPrefix.GetMemory(_severity);
            var flagText = _errorFlag.ToString().AsMemory();//alloc

            Memory<char> flagInfoBuffer = new char[addition.Length + severity.Length + flagText.Length]; //array pooling?

            addition.CopyTo(flagInfoBuffer);
            severity.CopyTo(flagInfoBuffer[addition.Length..]);
            flagText.CopyTo(flagInfoBuffer[(severity.Length + addition.Length)..]);
 
            return flagInfoBuffer;
        }
    }
}