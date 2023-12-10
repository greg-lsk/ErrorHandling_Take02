using ErrorHandling.Rule;


namespace ErrorHandling.Evaluating.Actions;

internal static class DirectAction<TSubject>
{
    internal readonly static EvaluationAction<TSubject> Singular = (subject, rule, report, behavior) =>
    {
        var predicate = rule.Criterion as Func<TSubject, bool>;

        if (predicate!.Invoke(subject)) return true;

        Console.WriteLine($"{rule.IncomplianceTag} {rule.IncomplianceSeverity}");

        return false;
    };

    internal readonly static EvaluationAction<TSubject> Sequencial = (subject, rule, report, behavior) =>
    {
        var sequence = rule.Criterion as RuleSequence<TSubject>;

        DomainRule nextRule;
        EvaluationAction<TSubject> nextAction;
        bool incomplianceDetected = false;

/*        for (int i = 0; i < sequence!.Length; ++i)
        {
            nextRule = sequence[i];
            nextAction = sequence.ActionFor(i);

            if (nextAction.Invoke(subject, nextRule, report, behavior)) continue;

            incomplianceDetected = true;
            if (sequence.ShortCircutsAt(i)) break;
            if (behavior == EvaluationBehavior.OnErrorStop) break;
        }

        if (incomplianceDetected)
            Console.WriteLine($"{rule.IncomplianceTag} {rule.IncomplianceSeverity}");*/

        return !incomplianceDetected;
    };
}