using ErrorHandling.EvaluationTemplates;
using ErrorHandling.EvaluationTemplates.Abstractions;


namespace ErrorHandling.EvaluationBuilders;

public sealed class BatchEvaluationBuilder<TSubject> : EvaluationBuilder<TSubject>
{
    private Evaluation<TSubject>[]? _shortCircutEvaluations;
    private int ShortCircuitCount => _shortCircutEvaluations?.Length ?? 0;

    private Evaluation<TSubject>[]? _regularEvaluations;
    private int RegularCount => _regularEvaluations?.Length ?? 0;

    private int NumberOfEvaluations => ShortCircuitCount + RegularCount;


    public BatchEvaluationBuilder<TSubject>
        WithShortCircutEvaluations(params Evaluation<TSubject>[] evaluations)
    {
        _shortCircutEvaluations = evaluations;
        return this;
    }

    public BatchEvaluationBuilder<TSubject>
        WithRegularEvaluations(params Evaluation<TSubject>[] evaluations)
    {
        _regularEvaluations = evaluations;
        return this;
    }

    internal override EvaluationTemplate<TSubject> BuildTemplate()
    {
        if (NumberOfEvaluations == 0)
            throw new InvalidOperationException("at least one evaluation must be provided");

        if (_severity is null)
            throw new InvalidOperationException("severity must be provided");

        return new BatchEvaluationTemplate<TSubject>
            (_shortCircutEvaluations, _regularEvaluations, _severity.Value, _successTag, _incomplianceTag);
    }
}