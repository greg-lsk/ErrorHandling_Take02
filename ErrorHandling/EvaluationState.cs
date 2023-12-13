using System.Runtime.CompilerServices;

using ErrorHandling.Reporting;
using ErrorHandling.Reporting.Logging;
using ErrorHandling.Reporting.CallStackInfo;


namespace ErrorHandling;

public readonly struct EvaluationState
{
    internal EvaluationInfo TraceInfo { get; }
    internal EvaluationReport Report { get; }


    internal EvaluationState(string callerMemberName, int callerLineNumber)
    {
        Report = new();
        TraceInfo = new(callerMemberName, callerLineNumber);
    }


    public static EvaluationState Init<TCategory>(
        [CallerMemberName] string callerMemberName = null!,
        [CallerLineNumber] int callerLineNumber = 0)
    {
        var logger = EvaluationLogger.Get<TCategory>();
        return new(callerMemberName, callerLineNumber);
    }
}