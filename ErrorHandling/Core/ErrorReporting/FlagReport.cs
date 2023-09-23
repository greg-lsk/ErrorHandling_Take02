using ErrorHandling.Public;

namespace ErrorHandling.Core.ErrorReporting;

internal class FlagReport : IReport
{
    private readonly Enum _errorFlag;
    private readonly IncomplianceSeverity _severity;


    internal FlagReport(Enum errorFlag, IncomplianceSeverity severity)
    {
        _errorFlag = errorFlag;
        _severity = severity;
    }


    public override string ToString() => $" -[{_severity}]: {_errorFlag}";
}