using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;

using ErrorHandling.Rule;
using ErrorHandling.Reporting;
using ErrorHandling.Reporting.Logging;
using ErrorHandling.Reporting.CallStackInfo;
using ErrorHandling.ResultUtilities;
using ErrorHandling.Evaluating.Actions;


namespace ErrorHandling.Evaluating;

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


    public bool Evaluate<TSubject>(TSubject subject, DomainRule rule, EvaluationBehavior behavior)
    {
        return (rule as IEvaluationActionCarrier<TSubject>)!.Action(subject, rule, Report, behavior);
    }
        


    public Result<TResult> YieldResult<TResult>(Func<TResult> yieldDelegate)
    {
        if (Report.HasErrors) return Result<TResult>();
        
        return new(yieldDelegate.Invoke());
    }

    public VoidResult YieldVoid(Action yieldAction)
    {
        if (Report.HasErrors) return Void();

        yieldAction.Invoke();
        return new();
    }


    private VoidResult Void()
    {
        Logger.Log(
            LogLevel.Error,
            "{TraceInfo}" +
            "      {ReportString}" +
            "\n      [EvaluationID]:{ReportID}", TraceInfo, Report.ToString(), Report.ReportId);

        return new(new ResultReport(Report.ReportId, Report.Flags!));
    }
    private Result<TReturn> Result<TReturn>()
    {
        Logger.Log(
            LogLevel.Error,
            "{TraceInfo}" +
            "      {ReportString}" +
            "\n      [EvaluationID]:{ReportID}", TraceInfo, Report.ToString(), Report.ReportId);

        return new(new ResultReport(Report.ReportId, Report.Flags!));
    }
}