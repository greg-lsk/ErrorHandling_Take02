namespace ErrorHandling.Rule;

public class RuleSequence<TSubject>
{
    private readonly Rule<TSubject>[]? _shortCircutRules;
    private readonly Rule<TSubject>[]? _rules;

    internal Rule<TSubject> this[int index] =>
        index < (_shortCircutRules?.Length ?? 0)
        ? _shortCircutRules![index]
        : _rules![index];

    internal int Length => (_shortCircutRules?.Length ?? 0) + (_rules?.Length ?? 0);


    public RuleSequence(params (Rule<TSubject> rule, bool enablesShortCircuiting)[] rules)
    {
        _shortCircutRules = rules
            .Where(r => r.enablesShortCircuiting)
            .Select(r => r.rule)
            .ToArray();

        _rules = rules
            .Where(r => !r.enablesShortCircuiting)
            .Select(r => r.rule)
            .ToArray();
    }

    internal bool ShortCircutsAt(int index) => index < (_shortCircutRules?.Length ?? 0);
}