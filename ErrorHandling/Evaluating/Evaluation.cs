using ErrorHandling.Reporting;
using ErrorHandling.Reporting.CallStackInfo;
using System.Runtime.CompilerServices;
using ErrorHandling.ResultUtilities;
using Microsoft.Extensions.Logging;
using ErrorHandling.Reporting.Logging;

namespace ErrorHandling.Evaluating;

public readonly partial struct Evaluation
{
    private readonly ILogger _logger;

    internal EvaluationInfo TraceInfo { get; }
    internal EvaluationReport Report { get; }


    internal Evaluation(ILogger logger, string callerFilePath, string callerMemberName, int callerLineNumber)
    {
        _logger = logger;
        Report = new();
        TraceInfo = new(callerFilePath, callerMemberName, callerLineNumber);
    }

/*    public static Evaluation Init(
        [CallerFilePath] string callerFilePath = null!,
        [CallerMemberName] string callerMemberName = null!,
        [CallerLineNumber] int callerLineNumber = 0)
    {
        return new(callerFilePath, callerMemberName, callerLineNumber);
    }*/
    public static Evaluation Init<TCategory>(
    [CallerFilePath] string callerFilePath = null!,
    [CallerMemberName] string callerMemberName = null!,
    [CallerLineNumber] int callerLineNumber = 0)
    {
        var logger = EvaluationLogger.Get<TCategory>();
        return new(logger, callerFilePath, callerMemberName, callerLineNumber);
    }


    public Evaluator<TSubject> Evaluate<TSubject>(TSubject? subject)
    {
        return new(subject, Report);
    }

    public void Evaluate(IResult result)
    {
        if (result.IsValid) return;

        Report.LogExternal(result.Report!);
    }

    public void Evaluate(params IResult[] results)
    {
        for(int i = 0; i<results.Length; ++i)
            if (!results[i].IsValid) Report.LogExternal(results[i].Report!);
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
        _logger.Log(
            LogLevel.Error,
            "{TraceInfo}" +
            "\n      {ReportString}" +
            "\n      [EvaluationID]:{ReportID}", TraceInfo, Report.StringRep(), Report.ReportId);

        return new(new ResultReport(Report.ReportId, Report.Flags!));
    }
    private Result<TReturn> Result<TReturn>()
    {
        _logger.Log(
            LogLevel.Error,
            "{TraceInfo}" +
            "\n      {ReportString}" +
            "\n      [EvaluationID]:{ReportID}", TraceInfo, Report.StringRep(), Report.ReportId);

        return new(new ResultReport(Report.ReportId, Report.Flags!));
    }
}