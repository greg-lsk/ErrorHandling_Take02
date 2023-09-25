namespace ErrorHandling.Reporting.CallStackInfo;

internal readonly struct EvaluationInfo
{
    private readonly string _callerFilePath;
    private readonly string _callerMethodName;
    private readonly int _callerLineNumber;


    internal EvaluationInfo(string callerFilePath, string callerMethodName, int callerLineNumber)
    {
        _callerFilePath = callerFilePath;
        _callerMethodName = callerMethodName;
        _callerLineNumber = callerLineNumber;
    }


    public override readonly string ToString() =>
        $"[File]:         {_callerFilePath}\n" +
        $"[Method, Line]: {_callerMethodName}, {_callerLineNumber}\n";
}