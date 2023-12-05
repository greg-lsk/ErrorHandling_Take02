namespace ErrorHandling.Rule;

public class RuleSequence<TSubject>
{
    internal readonly DomainRule[]? ShortCircutRules;
    internal readonly DomainRule[] Rules;

    public RuleSequence(params (DomainRule rule, bool enablesShortCircuiting)[] rules)
    {
        ShortCircutRules = rules
            .Where(r => r.enablesShortCircuiting)
            .Select(r => r.rule)
            .ToArray();

        Rules = rules
            .Where(r => !r.enablesShortCircuiting)
            .Select(r => r.rule)
            .ToArray();
    }
}