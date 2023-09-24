using ErrorHandling.Core.ErrorReporting;
using System.Runtime.CompilerServices;


namespace ErrorHandling.Core.Evaluation;

internal enum UniversalFlags
{
    NullDetected
}

internal enum AttachingBehaviour
{
    Accumulative,
    OnErrorStop
}

public readonly struct Evaluation
{
    private readonly ReportCollection _reports;

    internal Evaluation(string callerFilePath, string callerMemberName, int callerLineNumber)
    {
        _reports = new(0, callerFilePath, callerMemberName, callerLineNumber);
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
        return new(subject, _reports, callerLineNumber);
    }
}