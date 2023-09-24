namespace ErrorHandling.Core.ErrorReporting;

internal readonly struct EvaluatorReport
{
    private readonly int _callerLineNumber;


    internal EvaluatorReport(int callerLineNumber) => _callerLineNumber = callerLineNumber;


    public override readonly string ToString()
        => "Subject evaluated at [Line]:" + _callerLineNumber + "\n";
}