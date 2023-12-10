using ErrorHandling.Evaluating;


namespace ErrorHandling.Drafts;

public sealed class BatchEvaluationTemplate<TSubject> : Template
{
    private Evaluation<TSubject>[]? _shortCircutEvaluations;
    private Evaluation<TSubject>[]? _regularEvaluations;

    private Evaluation<TSubject> this[int index] =>
        ShortCircutsAt(index)
        ? _shortCircutEvaluations![index]
        : _regularEvaluations![index - ShortCircutCount];

    private int ShortCircutCount => (_shortCircutEvaluations?.Length ?? 0);
    private int RegularCount => (_regularEvaluations?.Length ?? 0);
    private int Length => ShortCircutCount + RegularCount;


    public BatchEvaluationTemplate<TSubject> 
        WithShortCircutEvaluations(params Evaluation<TSubject>[] evaluations)
    {
        _shortCircutEvaluations = evaluations;
        return this;
    }

    public BatchEvaluationTemplate<TSubject> 
        WithRegularEvaluations(params Evaluation<TSubject>[] evaluations)
    {
        _regularEvaluations = evaluations;
        return this;
    }

    public override BatchEvaluationTemplate<TSubject> WithSeverity(IncomplianceSeverity severity)
    {
        _severity = severity;
        return this;
    }

    public override BatchEvaluationTemplate<TSubject> WithSuccessTag(Enum successTag)
    {
        _successTag = successTag;
        return this;
    }

    public override BatchEvaluationTemplate<TSubject> WithIncomplianceTag(Enum incomplianceTag)
    {
        _incomplianceTag = incomplianceTag;
        return this;
    }

    public Evaluation<TSubject> Build()
    {
        return (TSubject subject, in EvaluationState state) =>
        {
            bool incomplianceDetected = false;

            for(int i=0; i<Length; ++i)
            {
                if (this[i].Invoke(subject, in state)) continue;

                incomplianceDetected = true;
                if (ShortCircutsAt(i)) break;
            }

            if (!incomplianceDetected)
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


    private bool ShortCircutsAt(int index) => index < (_shortCircutEvaluations?.Length ?? 0);
}


public class Test<TSubject, TProperty>
{
    private readonly Func<TSubject, TProperty> _selector;
    private readonly Evaluation<TProperty> _evaluation;

    private readonly IncomplianceSeverity _severity;

    private readonly Enum? _successTag;
    private readonly Enum? _incomplianceTag;

    public Test() { }

    public Test(Func<TSubject, TProperty> selector,
                Evaluation<TProperty> evaluation,
                IncomplianceSeverity severity,
                Enum? successTag,
                Enum? incomplianceTag)
    {
        _selector = selector;
        _severity = severity;
        _successTag = successTag;
        _incomplianceTag = incomplianceTag;
        _evaluation = evaluation;
    }

    public void Selection(Func<TSubject, TProperty> selector, Evaluation<TProperty> evaluation) { }

    public Evaluation<TSubject> Build()
    {
        return (TSubject subject, in EvaluationState state) =>
        {
            if (_evaluation(_selector(subject), in state)) return true;

            return false;
        };
    }
}