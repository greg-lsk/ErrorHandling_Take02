using ErrorHandling.Reporting;
using ErrorHandling.Reporting.Collections;


namespace ErrorHandling;

public class Result<T>
{
    public T? Value { get; private set; }

    internal readonly EvaluationReport Report;


    internal Result(T value, EvaluationReport report)
    {
            Value = value;
            Report = report;
    }

    internal Result(EvaluationReport report)
    {
        Value = default;
        Report = report;
    }
}