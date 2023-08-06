using ErrorHandling.Public;


namespace ErrorHandling.Core;

internal class Result<T> : IResult<T>
{
    private string _callerInfo;

    public T? Value { get; private set; } = default;
    internal List<Enum> Flags { get; private set; } = new();

    internal Result(List<Enum> flags, string callerInfo)
    {
        Flags = flags;
        _callerInfo = callerInfo;
    }

    public bool IsValid => Flags.Count == 0;

    public IResult<T> Bind(Func<T> bindAction)
    {
        if (Flags.Count == 0)
        {
            Value = bindAction.Invoke();
            return this;
        }

        Value = default;
        return this;
    }

    public string ErrorsCaptured() =>
        Flags.Count > 0
        ? $"{_callerInfo}\n{string.Join(", ", Flags.Select(flag => flag.ToString()))}"
        : $"{_callerInfo}\nNoErrors";
}
