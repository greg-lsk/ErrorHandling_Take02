using ErrorHandling.Rule;


namespace ErrorHandling.Evaluating.Action;

internal static class IndirectAction<TSubject, TProperty>
{
    internal readonly static EvaluationAction<TSubject> Singular
        = (in Evaluation e, TSubject s, DomainRule r) =>
        {
            var rule = r as IndirectRule<TSubject, TProperty>;
            var subject = rule!.Selector.Invoke(s);
            var criterion = r.Criterion as Func<TProperty, bool>;

            return EvaluationCenter.Evaluate(in e,
                                             subject,
                                             criterion!,
                                             r.IncomplianceTag,
                                             r.IncomplianceSeverity);
        };

    internal readonly static EvaluationAction<TSubject> Sequencial
        = (in Evaluation e, TSubject s, DomainRule r) =>
        {
            var rule = r as IndirectRule<TSubject, TProperty>;
            var subject = rule!.Selector.Invoke(s);
            var criterion = r.Criterion as RuleSequence<TProperty>;

            return true;
        };
}