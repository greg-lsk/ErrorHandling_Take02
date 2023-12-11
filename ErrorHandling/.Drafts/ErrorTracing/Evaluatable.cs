namespace ErrorHandling.Drafts;

public readonly struct Evaluatable<TSubject> where TSubject : struct
{
    internal readonly int Id;
    public readonly TSubject Value;

    public Evaluatable(int id, in TSubject value)
    {
        Id = id;
        Value = value;
    }

    public Evaluatable(int id, TSubject value)
    {
        Id = id;
        Value = value;
    }
}