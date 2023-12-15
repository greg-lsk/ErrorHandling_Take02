namespace Domain.Equality;
public static class Equity
{
    public static bool Inferred<T>(T? left, T? right)
    {
        if (ReferenceEquals(left, right)) return true;
        if (left is null || right is null) return false;

        return false;
    }

    public static EqualityComparer<T> Comparer<T>(EquityDelegate<T> equals, HashDelegate<T> hash)
        => EqualityComparer<T>.Create(equals.Invoke, hash.Invoke);
}