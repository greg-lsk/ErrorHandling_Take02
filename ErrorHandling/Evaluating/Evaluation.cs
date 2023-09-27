using ErrorHandling.Reporting;
using ErrorHandling.Reporting.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.JavaScript;


namespace ErrorHandling.Evaluating;

public readonly struct Evaluation
{
    internal readonly ReportCollection Reports;

    internal Evaluation(string callerFilePath, string callerMemberName, int callerLineNumber)
    {
        Reports = new( new(callerFilePath, callerMemberName, callerLineNumber) );
    }

    public static Evaluation Init(
        [CallerFilePath] string callerFilePath = null!,
        [CallerMemberName] string callerMemberName = null!,
        [CallerLineNumber] int callerLineNumber = 0)
    {
        return new(callerFilePath, callerMemberName, callerLineNumber);
    }

    public Evaluator<TSubject> Evaluate<TSubject>(TSubject? subject,
                                                  [CallerLineNumber] int callerLineNumber = 0)
    {
        return new(subject, callerLineNumber, this);
    }

    public Evaluation Evaluate<TSubject>(Result<TSubject> result,
                                         [CallerLineNumber] int callerLineNumber = 0)
    {
        ReportSynchronizer.MergeReports(Reports, result.Reports);
        return this;
    }

    public Result<T> YieldResult<T>(Func<T> createDelegate)
    {
        return new Result<T>(createDelegate.Invoke(), Reports);
    }

    public void Print() => Reports.Print();
}