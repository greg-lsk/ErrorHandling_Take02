using ErrorHandling.Reporting;
using System.Runtime.CompilerServices;


namespace ErrorHandling.Evaluation;

public readonly struct Evaluation
{
    internal readonly EvaluationReport Report;

    internal Evaluation(string callerFilePath, string callerMemberName, int callerLineNumber)
    {
        Report = new(callerFilePath, callerMemberName, callerLineNumber);
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
        return new(subject, callerLineNumber, this);
    }

    public void Print() => Report.Print();
}