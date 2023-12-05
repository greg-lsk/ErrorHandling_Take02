namespace ErrorHandling.Rule;

public class RuleSequence<TSubject>
{
    internal readonly DomainRulez<TSubject>[]? ShortCircutRules;
    internal readonly DomainRulez<TSubject>[] Rules;

    public RuleSequence(params (
        Func<TSubject, bool> predicate, 
        Enum incomplianceTag, 
        IncomplianceSeverity incomplianceSeverity, 
        bool enablesShortCircuiting)[] rules)
    {
        ShortCircutRules = rules
            .Where(rule => rule.enablesShortCircuiting)
            .Select(rule => new DomainRulez<TSubject>(
                rule.predicate,
                rule.incomplianceTag,
                rule.incomplianceSeverity)
            ).ToArray();

        Rules = rules
            .Where(rule => !rule.enablesShortCircuiting)
            .Select(rule => new DomainRulez<TSubject>(
                rule.predicate, 
                rule.incomplianceTag, 
                rule.incomplianceSeverity)
            ).ToArray();
    }
}