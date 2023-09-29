using ErrorHandling.Reporting;


namespace ErrorHandling.Result;

public class Result<T> : IResult
{
    public T? Value { get; private set; }
    public ResultReport? Report { get; private set; }

    public bool IsValid => Report is null;

    internal Result(T value)
    {
        Value = value;
    }

    internal Result(ResultReport report)
    {
        Value = default;
        Report = report;
    }
}