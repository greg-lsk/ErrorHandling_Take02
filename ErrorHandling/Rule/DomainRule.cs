namespace ErrorHandling.Rule;

public readonly struct DomainRule<TSubject>
{
    private readonly Func<TSubject, bool> _predicate;

    internal readonly Enum IncomplianceTag;
    internal readonly IncomplianceSeverity IncomplianceSeverity;


    internal DomainRule(Func<TSubject, bool> predicate,
                        Enum incomplianceTag,
                        IncomplianceSeverity incomplianceSeverity)
    {
        _predicate = predicate;
        IncomplianceTag = incomplianceTag;
        IncomplianceSeverity = incomplianceSeverity;
    }


    internal bool AppliesTo(TSubject subject) => _predicate.Invoke(subject);
}