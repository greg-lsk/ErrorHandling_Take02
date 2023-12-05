namespace ErrorHandling.Rule;

public static class RuleBuilder
{
    public static DomainRule Create<TSubject>(Func<TSubject, bool> predicate,
                                              Enum incomplianceTag,
                                              IncomplianceSeverity incomplianceSeverity)
        => new DirectRule<TSubject>(predicate, incomplianceTag, incomplianceSeverity);


    public static DomainRule Create<TSubject>(RuleSequence<TSubject> sequence,
                                              Enum incomplianceTag,
                                              IncomplianceSeverity incomplianceSeverity)
        => new DirectRule<TSubject>(sequence, incomplianceTag, incomplianceSeverity);


    public static DomainRule Create<TSubject, TProperty>(Func<TSubject, TProperty> selector,
                                                         Func<TSubject, bool> predicate,
                                                         Enum incomplianceTag,
                                                         IncomplianceSeverity incomplianceSeverity)
        => new IndirectRule<TSubject, TProperty>(predicate, incomplianceTag, incomplianceSeverity, selector);


    public static DomainRule Create<TSubject, TProperty>(Func<TSubject, TProperty> selector,
                                                         RuleSequence<TProperty> sequence,
                                                         Enum incomplianceTag,
                                                         IncomplianceSeverity incomplianceSeverity)
    => new IndirectRule<TSubject, TProperty>(sequence, incomplianceTag, incomplianceSeverity, selector);
}