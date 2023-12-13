using ErrorHandling.ResultUtilities;


namespace ErrorHandling;

public class Result<T> : IResult
{
    public T? Value { get; private set; }
    public ResultReport? Report { get; private set; }

    public bool IsValid => Report is null;

    public Result(T value)
    {
        Value = value;
    }

    public Result() { }

    public Result(ResultReport report)
    {
        Value = default;
        Report = report;
    }

    public Result<T> ActUpon(Action<T> action)
    {
        if (!IsValid) return this;

        action.Invoke(Value!);

        return this;
    }
}