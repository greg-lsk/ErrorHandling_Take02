using ErrorHandling.Templates.Abstractions;


namespace ErrorHandling.Templates;

internal class ComposedEvaluationTemplate<TSubject, TProperty> : EvaluationTemplate<TSubject>
{
    private readonly PropertySelector<TSubject, TProperty> _selector;
    private readonly Evaluation<TProperty> _evaluation;


    internal ComposedEvaluationTemplate(PropertySelector<TSubject, TProperty> selector,
                                        Evaluation<TProperty> evaluation,
                                        IncomplianceSeverity severity,
                                        Enum? successTag,
                                        Enum? incomplianceTag)
        :base(severity, successTag, incomplianceTag)
    {
        _selector = selector;
        _evaluation = evaluation;
    }


    internal override Evaluation<TSubject> ConstructEvaluation() =>
    (TSubject subject, in EvaluationState state) =>
    {
        var successfulEvaluation = _evaluation(_selector(subject), in state);

        if (successfulEvaluation)
        {
            if (_successTag is not null) Console.WriteLine($"[Success]:{_successTag}");
            else Console.WriteLine($"[Success]");

            return true;
        }
        else
        {
            if (_incomplianceTag is not null) Console.WriteLine($"[{_severity}]:{_incomplianceTag}");
            else Console.WriteLine($"[{_severity}]");

            return false;
        }
    };
}