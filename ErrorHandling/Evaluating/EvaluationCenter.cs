using ErrorHandling.Rule;
using ErrorHandling.Reporting;
using ErrorHandling.Evaluating.Actions;


namespace ErrorHandling.Evaluating;

internal static class EvaluationCenter
{
    internal static bool Evaluate<TSubject>(TSubject subject,
                                            Func<TSubject, bool> predicate,
                                            EvaluationReport report,
                                            EvaluationBehavior behavior,
                                            Enum incomplianceTag,
                                            IncomplianceSeverity severity)
    {
        if (predicate.Invoke(subject)) return true;
            
        Console.WriteLine($"{incomplianceTag} {severity}");

        return false;
    }

    internal static bool Evaluate<TSubject>(TSubject subject,
                                            RuleSequence<TSubject> sequence,
                                            EvaluationReport report,
                                            EvaluationBehavior behavior,
                                            Enum incomplianceTag,
                                            IncomplianceSeverity severity)
    {
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
        }*/

        if (incomplianceDetected)
            Console.WriteLine($"{incomplianceTag} {severity}");

        return !incomplianceDetected;
    }
}