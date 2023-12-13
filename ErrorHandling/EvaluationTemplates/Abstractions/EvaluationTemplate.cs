namespace ErrorHandling.EvaluationTemplates.Abstractions;

internal abstract class EvaluationTemplate<TSubject>
{
    protected readonly IncomplianceSeverity _severity;
    protected readonly Enum? _successTag;
    protected readonly Enum? _incomplianceTag;


    internal EvaluationTemplate(IncomplianceSeverity severity, Enum? successTag, Enum? incomplianceTag)
    {
        _severity = severity;
        _successTag = successTag;
        _incomplianceTag = incomplianceTag;
    }


    internal abstract Evaluation<TSubject> ConstructEvaluation();
}