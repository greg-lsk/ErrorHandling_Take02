using ErrorHandling.Templates;
using ErrorHandling.Templates.Abstractions;


namespace ErrorHandling.Builders.Internal;

internal sealed class ComposedEvaluationBuilder<TSubject, TProperty> : EvaluationBuilder<TSubject>
{
    private PropertySelector<TSubject, TProperty>? _selector;
    private Evaluation<TProperty>? _evaluation;


    public ComposedEvaluationBuilder<TSubject, TProperty> WithSelection(
        PropertySelector<TSubject, TProperty> selector,
        Evaluation<TProperty> evaluation)
    {
        _selector = selector;
        _evaluation = evaluation;
        return this;
    }


    internal override EvaluationTemplate<TSubject> BuildTemplate()
    {
        if (_selector is null) throw new InvalidOperationException("selection must be provided");

        if (_evaluation is null) throw new InvalidOperationException("selection must be provided");

        if (_severity is null) throw new InvalidOperationException("severity must be provided");

        return new ComposedEvaluationTemplate<TSubject, TProperty>
            (_selector, _evaluation, _severity.Value, _successTag, _incomplianceTag);
    }
}