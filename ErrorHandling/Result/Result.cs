using ErrorHandling.Reporting;


namespace ErrorHandling.Result;

public class Result<T> : IResult
{
    public T? Value { get; private set; }
    public ResultReport? Report { get; private set; }

    public bool IsValid => Report is null;

    public Result(T value)
    {
        Value = value;
    }

    public Result(ResultReport report)
    {
        Value = default;
        Report = report;
    }

    public Result<T> ActUpon(Func<T, IResult> action)
    {
        if(!IsValid) return this;
        
        var result = action.Invoke(Value!);

        if (result.IsValid) return this;

/*        if (Report is null)
            Report = new(Guid.NewGuid(), result.Report!.Flags!);*/

        return this;
    }
    public Result<T> ActUpon(Action<T> action)
    {
        if (!IsValid) return this;

        action.Invoke(Value!);

        return this;
    }
}