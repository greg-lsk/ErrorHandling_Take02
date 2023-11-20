namespace ErrorHandling.Rule;

public static class RuleBuilder
{
    public static DomainRule<TSubject> Create<TSubject>(Func<TSubject, bool> predicate,
                                                        Enum incomplianceTag,
                                                        IncomplianceSeverity incomplianceSeverity)
        => new(predicate, incomplianceTag, incomplianceSeverity);
}