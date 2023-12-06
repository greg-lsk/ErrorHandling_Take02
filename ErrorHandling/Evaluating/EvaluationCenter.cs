using ErrorHandling.Rule;


namespace ErrorHandling.Evaluating;

internal static class EvaluationCenter
{
    internal static bool Evaluate<TSubject, TProperty>(in Evaluation evaluation,
                                                       TSubject subject,
                                                       DomainRule rule)
    {
        var indirectRule = rule as IndirectRule<TSubject, TProperty>;

        return true;
    }

    internal static bool Evaluate<TSubject>(in Evaluation evaluation,
                                            TSubject subject,
                                            DomainRule rule)
    {
        var directRule = rule as DirectRule<TSubject>;

        return true;
    }
}