namespace ErrorHandling.Public;

public interface IResult<T>
{
    public T? Value { get; }
    public bool IsValid { get; }

    public IResult<T> Bind(Func<T> bindAction);
    public string ErrorsCaptured();
}