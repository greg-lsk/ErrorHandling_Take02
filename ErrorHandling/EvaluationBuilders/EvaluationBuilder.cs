using ErrorHandling.EvaluationTemplates.Abstractions;


namespace ErrorHandling.EvaluationBuilders;

public abstract class EvaluationBuilder<TSubject>
{
    protected IncomplianceSeverity? _severity;

    protected Enum? _successTag;
    protected Enum? _incomplianceTag;


    public EvaluationBuilder<TSubject> WithSeverity(IncomplianceSeverity severity)
    {
        _severity = severity;
        return this;
    }

    public EvaluationBuilder<TSubject> WithSuccessTag(Enum? successTag)
    {
        _successTag = successTag;
        return this;
    }

    public EvaluationBuilder<TSubject> WithIncomplianceTag(Enum? incomplianceTag)
    {
        _incomplianceTag = incomplianceTag;
        return this;
    }

    public Evaluation<TSubject> Build() => BuildTemplate().ConstructEvaluation();


    internal abstract EvaluationTemplate<TSubject> BuildTemplate();
}