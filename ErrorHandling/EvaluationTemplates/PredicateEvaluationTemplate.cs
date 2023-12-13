using ErrorHandling.EvaluationTemplates.Abstractions;


namespace ErrorHandling.EvaluationTemplates;

internal class PredicateEvaluationTemplate<TSubject> : EvaluationTemplate<TSubject>
{
    private readonly EvaluationPredicate<TSubject> _predicate;


    internal PredicateEvaluationTemplate(EvaluationPredicate<TSubject> predicate,
                                         IncomplianceSeverity severity,
                                         Enum? successTag,
                                         Enum? incomplianceTag)
        : base(severity, successTag, incomplianceTag)
    {
        _predicate = predicate;
    }


    internal override Evaluation<TSubject> ConstructEvaluation() =>
    (TSubject subject, in EvaluationState state) =>
    {
        var successfulEvaluation = _predicate.Invoke(subject);

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