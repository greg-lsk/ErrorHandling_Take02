namespace ErrorHandling.Rule;

public class RuleSequence<TSubject>
{
    internal readonly DomainRule<TSubject>[] Rules;

    public RuleSequence(params (
        Func<TSubject, bool> predicate, 
        Enum incomplianceTag, 
        IncomplianceSeverity incomplianceSeverity)[] rules)
    {
        Rules = rules.Select(rule => new DomainRule<TSubject>
        (
            rule.predicate, 
            rule.incomplianceTag, 
            rule.incomplianceSeverity)
        ).ToArray();
    }
}