using ErrorHandling.Public;


namespace ErrorHandling.Core.ErrorReporting;

internal readonly struct FlagReport
{
    private readonly Enum _errorFlag;
    private readonly IncomplianceSeverity _severity;


    internal FlagReport(Enum errorFlag, IncomplianceSeverity severity)
    {
        _errorFlag = errorFlag;
        _severity = severity;
    }


    public override readonly string ToString() => $" -[{_severity}]: {_errorFlag}";
}