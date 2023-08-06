namespace ErrorHandling.Core;

internal readonly struct CallerInfo
{
    private readonly string _callerFilePath;
    private readonly string _callerMethodName;
    private readonly int _callerLineNumber;

    internal CallerInfo(string callerFilePath, string callerMethodName, int callerLineNumber)
    {
        _callerFilePath = callerFilePath;
        _callerMethodName = callerMethodName;
        _callerLineNumber = callerLineNumber;
    }

    public override string ToString() =>
        $"CallerFilePath:   {_callerFilePath}\n" +
        $"CallerMethodName: {_callerMethodName}\n" +
        $"CallerLineNumber: {_callerLineNumber}";
}