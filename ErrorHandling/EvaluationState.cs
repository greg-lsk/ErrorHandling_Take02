using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;

using ErrorHandling.Reporting;
using ErrorHandling.Reporting.Logging;
using ErrorHandling.Reporting.CallStackInfo;


namespace ErrorHandling;

public readonly partial struct EvaluationState
{
    private ILogger Logger { get; }

    internal EvaluationInfo TraceInfo { get; }
    internal EvaluationReport Report { get; }


    internal EvaluationState(ILogger logger, string callerMemberName, int callerLineNumber)
    {
        Logger = logger;
        Report = new();
        TraceInfo = new(callerMemberName, callerLineNumber);
    }


    public static EvaluationState Init<TCategory>(
        [CallerMemberName] string callerMemberName = null!,
        [CallerLineNumber] int callerLineNumber = 0)
    {
        var logger = EvaluationLogger.Get<TCategory>();
        return new(logger, callerMemberName, callerLineNumber);
    }
}