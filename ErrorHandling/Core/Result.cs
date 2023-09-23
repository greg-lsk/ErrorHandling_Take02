using ErrorHandling.Core.ErrorReporting;


namespace ErrorHandling.Core;

public class Result<T>
{
    public T? Value { get; private set; }

    private readonly EvaluationReport Report;

    internal Result(T value, EvaluationReport report) 
    {
        Value = value;
        Report = report;
    }

    public override string ToString() => Report.ToString();
}