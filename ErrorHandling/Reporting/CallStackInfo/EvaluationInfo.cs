namespace ErrorHandling.Reporting.CallStackInfo;

internal readonly struct EvaluationInfo
{
    private readonly string _callerMethodName;
    private readonly int _callerLineNumber;


    internal EvaluationInfo(string callerMethodName, int callerLineNumber)
    {
        _callerMethodName = callerMethodName;
        _callerLineNumber = callerLineNumber;
    }


    public override readonly string ToString() =>
        $"[Method, Line]: {_callerMethodName}, {_callerLineNumber}";
} 