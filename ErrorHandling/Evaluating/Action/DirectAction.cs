using ErrorHandling.Rule;


namespace ErrorHandling.Evaluating.Action;

internal static class DirectAction<TSubject>
{
    internal readonly static EvaluationAction<TSubject> Singular
        = (in Evaluation e, TSubject s, DomainRule r) =>
        {
            var criterion = r.Criterion as Func<TSubject, bool>;

            return EvaluationCenter.Evaluate(in e,
                                             s,
                                             criterion!,
                                             r.IncomplianceTag,
                                             r.IncomplianceSeverity);
        };

    internal readonly static EvaluationAction<TSubject> Sequencial
        = (in Evaluation e, TSubject s, DomainRule r) =>
        {
            var criterion = r.Criterion as RuleSequence<TSubject>;

            return true;
        };
}