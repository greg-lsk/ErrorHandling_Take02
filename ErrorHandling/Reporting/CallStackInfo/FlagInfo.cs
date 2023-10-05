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
}