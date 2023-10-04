namespace ErrorHandling.ResultUtilities;

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

    public Result<T> ActUpon<TSelect, T1>(RefTypeSelector<T, TSelect> selector,
                                          OnRefTypeAction<T, TSelect, T1> action,
                                          T1 arg01)
        where TSelect : class
    {
        if (!IsValid) return this;

        var result = action.Invoke(selector, Value!, arg01);
        if (result.IsValid) return this;

        return this;
    }

    public Result<T> ActUpon<TSelect, T1>(StructSelector<T, TSelect> selector,
                                          OnStructAction<T, TSelect, T1> action,
                                          T1 arg01)
        where TSelect : struct
    {
        if (!IsValid) return this;

        var result = action.Invoke(selector, Value!, arg01);
        if (result.IsValid) return this;

        return this;
    }

    public Result<T> ActUpon(Action<T> action)
    {
        if (!IsValid) return this;

        action.Invoke(Value!);

        return this;
    }
}