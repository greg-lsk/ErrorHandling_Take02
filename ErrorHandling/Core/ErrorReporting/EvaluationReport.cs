namespace ErrorHandling.Core.ErrorReporting;

internal readonly struct EvaluationReport
{
    private readonly string _callerFilePath;
    private readonly string _callerMethodName;
    private readonly int _callerLineNumber;


    internal EvaluationReport(string callerFilePath, string callerMethodName, int callerLineNumber)
    {
        _callerFilePath = callerFilePath;
        _callerMethodName = callerMethodName;
        _callerLineNumber = callerLineNumber;
    }


    public override readonly string ToString() =>
        $"[File]:         {_callerFilePath}\n" +
        $"[Method, Line]: {_callerMethodName}, {_callerLineNumber}\n";
}