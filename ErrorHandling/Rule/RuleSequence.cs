namespace ErrorHandling.Rule;

public class RuleSequence<TSubject>
{
    internal readonly DomainRule<TSubject>[]? ShortCircutRules;
    internal readonly DomainRule<TSubject>[] Rules;

    public RuleSequence(params (
        Func<TSubject, bool> predicate, 
        Enum incomplianceTag, 
        IncomplianceSeverity incomplianceSeverity, 
        bool enablesShortCircuiting)[] rules)
    {
        ShortCircutRules = rules
            .Where(rule => rule.enablesShortCircuiting)
            .Select(rule => new DomainRule<TSubject>(
                rule.predicate,
                rule.incomplianceTag,
                rule.incomplianceSeverity)
            ).ToArray();

        Rules = rules
            .Where(rule => !rule.enablesShortCircuiting)
            .Select(rule => new DomainRule<TSubject>(
                rule.predicate, 
                rule.incomplianceTag, 
                rule.incomplianceSeverity)
            ).ToArray();
    }
}