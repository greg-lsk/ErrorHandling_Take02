using ErrorHandling.Reporting.CallStackInfo;

namespace ErrorHandling;

public class Result<T>
{
    public T? Value { get; private set; }

    private readonly EvaluationInfo Report;

    internal Result(T value, EvaluationInfo report)
    {
        Value = value;
        Report = report;
    }

    public override string ToString() => Report.ToString();
}