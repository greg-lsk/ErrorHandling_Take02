using ErrorHandling.Rule;


namespace ErrorHandling.Evaluating;

internal static class EvaluationCenter
{
    internal static bool Evaluate<TSubject>(in Evaluation evaluation,
                                            TSubject subject,
                                            Func<TSubject, bool> predicate,
                                            Enum incomplianceTag,
                                            IncomplianceSeverity severity)
    {
        return predicate.Invoke(subject);
    }

    internal static bool Evaluate<TSubject>(in Evaluation evaluation,
                                            TSubject subject,
                                            RuleSequence<TSubject> sequence,
                                            Enum incomplianceTag,
                                            IncomplianceSeverity severity)
    {
        return true;
    }
}