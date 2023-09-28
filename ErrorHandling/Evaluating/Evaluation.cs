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
        return new(subject, this);
    }

    public Evaluation Evaluate<TSubject>(Result<TSubject> result)
    {
        if (!result.Report.HasErrors) return this;
       
        Report.LogExternal(result.Report);
        return this;
    }

    public Result<T> YieldResult<T>(Func<T> createDelegate)
    {
        if (Report.HasErrors) Console.WriteLine($"{Report.StringRep()}\n{TraceInfo}");

        return new Result<T>(createDelegate.Invoke(), Report);
    }
}