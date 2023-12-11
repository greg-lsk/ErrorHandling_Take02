
namespace ErrorHandling.Drafts.Identification;

internal readonly struct RefId
{
    internal readonly object Ref;


    internal RefId(object @ref) { Ref = @ref; }


    internal readonly bool IsFor(object @ref) => Ref == @ref;

    internal readonly bool Equals(RefId refId) => Ref == refId.Ref;

    public static bool operator ==(RefId a, RefId b) => a.Equals(b);
    public static bool operator !=(RefId a, RefId b) => !a.Equals(b);

    public override readonly int GetHashCode() => Ref.GetHashCode();
}