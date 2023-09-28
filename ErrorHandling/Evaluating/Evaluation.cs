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

    public unsafe Evaluator<TSubject> Evaluate<TSubject>(TSubject? subject)
    {
        fixed (Evaluation* pointer = &this)
            return new(subject, pointer);
    }

    public unsafe Evaluation* Evaluate<TSubject>(Result<TSubject> result)
    {
        fixed (Evaluation* pointer = &this)
        {
            if (!result.Report.HasErrors) return pointer;

            Report.LogIncoming(result.Report);
            return pointer;
        }

    }

    public Result<T> YieldResult<T>(Func<T> createDelegate)
    {
        if (Report.HasErrors) Console.WriteLine(TraceInfo);

        return new Result<T>(createDelegate.Invoke(), Report);
    }
}