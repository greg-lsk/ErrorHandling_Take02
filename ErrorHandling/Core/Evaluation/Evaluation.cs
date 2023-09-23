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

public readonly ref struct Evaluation
{
    private readonly string _callerFilePath;
    private readonly string _callerMemberName;
    private readonly int _callerLineNumber;

    public Evaluation(string callerFilePath, string callerMemberName, int callerLineNumber)
    {
        _callerFilePath = callerFilePath;
        _callerMemberName = callerMemberName;
        _callerLineNumber = callerLineNumber;
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
        => new(subject, _callerFilePath, _callerMemberName, _callerLineNumber, callerLineNumber);
}