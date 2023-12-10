using ErrorHandling.Templates;
using ErrorHandling.Templates.Abstractions;


namespace ErrorHandling.Builders.Internal;

internal sealed class PredicateEvaluationBuilder<TSubject> : EvaluationBuilder<TSubject>
{
    private EvaluationPredicate<TSubject>? _predicate;

    public PredicateEvaluationBuilder<TSubject> WithPredicate(EvaluationPredicate<TSubject> predicate)
    {
        _predicate = predicate;
        return this;
    }

    internal override EvaluationTemplate<TSubject> BuildTemplate()
    {
        if (_predicate is null) throw new InvalidOperationException("predicate must be provided");

        if (_severity is null) throw new InvalidOperationException("severity must be provided");

        return new PredicateEvaluationTemplate<TSubject>
            (_predicate, _severity.Value, _successTag, _incomplianceTag);
    }
}