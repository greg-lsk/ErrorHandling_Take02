using ErrorHandling.Rule;


namespace ErrorHandling.Evaluating.Actions;

internal static class EvaluationActionProvider
{
    internal static EvaluationAction<TSubject> Get<TSubject>(DirectRule<TSubject> rule)
        => rule.Criterion switch
        {
            Func<TSubject, bool> => DirectAction<TSubject>.Singular,
            RuleSequence<TSubject> => DirectAction<TSubject>.Sequencial,
            _ => throw new Exception()
        };

    internal static EvaluationAction<TSubject> Get<TSubject, TProperty>(IndirectRule<TSubject, TProperty> rule)
        => rule.Criterion switch
        {
            Func<TProperty, bool> => IndirectAction<TSubject, TProperty>.Singular,
            RuleSequence<TProperty> => IndirectAction<TSubject, TProperty>.Sequencial,
            _ => throw new Exception()
        };
}