using ErrorHandling.Templates.Abstract;


namespace ErrorHandling.Templates;

internal class BatchEvaluationTemplate<TSubject> : EvaluationTemplate<TSubject>
{
    private readonly Evaluation<TSubject>[]? _shortCircuitEvaluations;
    private readonly Evaluation<TSubject>[]? _regularEvaluations;

    private Evaluation<TSubject> this[int index] =>
        ShortCircuitsAt(index)
        ? _shortCircuitEvaluations![index]
        : _regularEvaluations![index - ShortCircuitCount];

    private int ShortCircuitCount => (_shortCircuitEvaluations?.Length ?? 0);
    private int RegularCount => (_regularEvaluations?.Length ?? 0);
    private int Length => ShortCircuitCount + RegularCount;


    internal BatchEvaluationTemplate(EvaluationPredicate<TSubject> predicate,
                                     IncomplianceSeverity severity,
                                     Enum? successTag,
                                     Enum? incomplianceTag,
                                     Evaluation<TSubject>[]? shortCircuitEvaluations,
                                     Evaluation<TSubject>[]? regularEvaluations)
        : base(severity, successTag, incomplianceTag)
    {
        _shortCircuitEvaluations = shortCircuitEvaluations;
        _regularEvaluations = regularEvaluations;
    }


    internal override Evaluation<TSubject> ConstructEvaluation() =>
    (TSubject subject, in EvaluationState state) =>
    {
        bool successfulEvaluation = true;

        for (int i = 0; i < Length; ++i)
        {
            if (this[i].Invoke(subject, in state)) continue;

            successfulEvaluation = false;
            if (ShortCircuitsAt(i)) break;
        }

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


    private bool ShortCircuitsAt(int index) => index < (_shortCircuitEvaluations?.Length ?? 0);
}