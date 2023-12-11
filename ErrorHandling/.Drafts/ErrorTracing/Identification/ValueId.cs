namespace ErrorHandling.Drafts.Identification;

internal readonly struct ValueId
{
    internal readonly int Id;


    internal ValueId(int id) { Id = id; }


    internal readonly bool Equals(ValueId valueId) => Id == valueId.Id;

    public static bool operator ==(ValueId a, ValueId b) => a.Equals(b);
    public static bool operator !=(ValueId a, ValueId b) => !a.Equals(b);

    public override readonly int GetHashCode() => Id.GetHashCode();
}