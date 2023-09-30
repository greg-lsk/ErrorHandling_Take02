using ErrorHandling.Result;
using ErrorHandling.Reporting;
using ErrorHandling.Reporting.CallStackInfo;
using System.Runtime.CompilerServices;


namespace ErrorHandling.Evaluating;

public readonly struct Evaluation
{
    internal EvaluationInfo TraceInfo { get; }
    internal EvaluationReport Report { get; }


    internal Evaluation(string callerFilePath, string callerMemberName, int callerLineNumber)
    {
        Report = new();
        TraceInfo = new(callerFilePath, callerMemberName, callerLineNumber);
    }

    public static Evaluation Init(
        [CallerFilePath] string callerFilePath = null!,
        [CallerMemberName] string callerMemberName = null!,
        [CallerLineNumber] int callerLineNumber = 0)
    {
        return new(callerFilePath, callerMemberName, callerLineNumber);
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
    public VoidResult YieldVoid<T1>(T1 param01, Action<T1> yieldAction)
    {
        if (Report.HasErrors) return Void();

        yieldAction.Invoke(param01);
        return new();
    }


    private VoidResult Void()
    {
        Console.WriteLine($"{Report.StringRep()}\n{TraceInfo}");
        return new(new ResultReport(Report.ReportId, Report.Flags!));
    }
    private Result<TReturn> Result<TReturn>()
    {
        Console.WriteLine($"{Report.StringRep()}\n{TraceInfo}");
        return new(new ResultReport(Report.ReportId, Report.Flags!));
    }
}