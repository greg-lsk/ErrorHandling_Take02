namespace ErrorHandling.Rule;

public static class RuleBuilder
{
    public static DomainRule Create<TSubject>(Func<TSubject, bool> predicate,
                                              Enum incomplianceTag,
                                              IncomplianceSeverity severity)
        => new DirectRule<TSubject>(predicate, incomplianceTag, severity);


    public static DomainRule Create<TSubject>(RuleSequence<TSubject> sequence,
                                              Enum incomplianceTag,
                                              IncomplianceSeverity severity)
        => new DirectRule<TSubject>(sequence, incomplianceTag, severity);


    public static DomainRule Create<TSubject, TProperty>(Func<TSubject, TProperty> selector,
                                                         Func<TSubject, bool> predicate,
                                                         Enum incomplianceTag,
                                                         IncomplianceSeverity severity)
        => new IndirectRule<TSubject, TProperty>(predicate, incomplianceTag, severity, selector);


    public static DomainRule Create<TSubject, TProperty>(Func<TSubject, TProperty> selector,
                                                         RuleSequence<TProperty> sequence,
                                                         Enum incomplianceTag,
                                                         IncomplianceSeverity severity)
    => new IndirectRule<TSubject, TProperty>(sequence, incomplianceTag, severity, selector);
}