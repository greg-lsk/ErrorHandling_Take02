namespace ErrorHandling.Reporting.CallStackInfo;

internal readonly struct EvaluatorInfo
{
    private readonly int _callerLineNumber;


    internal EvaluatorInfo(int callerLineNumber) => _callerLineNumber = callerLineNumber;


    public override readonly string ToString()
        => "Subject evaluated at [Line]:" + _callerLineNumber + "\n";
}