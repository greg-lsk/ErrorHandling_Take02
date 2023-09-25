using ErrorHandling.Reporting;
using System.Runtime.CompilerServices;


namespace ErrorHandling.Evaluation;

public readonly struct Evaluation
{
    private readonly EvaluationReport _reports;

    internal Evaluation(string callerFilePath, string callerMemberName, int callerLineNumber)
    {
        _reports = new(callerFilePath, callerMemberName, callerLineNumber);
    }

    public static Evaluation Init(
        [CallerFilePath]   string callerFilePath = null!,
        [CallerMemberName] string callerMemberName = null!,
        [CallerLineNumber] int callerLineNumber = 0)
    {
        return new(callerFilePath, callerMemberName, callerLineNumber);
    }

    public Evaluator<TSubject> Evaluate<TSubject>(TSubject? subject,
                                                  [CallerLineNumber] int callerLineNumber = 0)
    {
        return new(subject, callerLineNumber, _reports);
    }
}