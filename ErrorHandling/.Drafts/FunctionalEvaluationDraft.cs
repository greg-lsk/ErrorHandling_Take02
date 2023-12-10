using ErrorHandling.Evaluating;


namespace ErrorHandling.Drafts;




public abstract class Evaluation
{
    public static EvaluationTemplate<TSubject> Builder<TSubject>() => new();

    public static BatchEvaluationTemplate<TSubject> BatchBuilder<TSubject>() => new();

    public static Test<TSubject, TProperty> SelectiveBuilder<TSubject, TProperty>() => new();
}

public abstract class Template
{
    protected IncomplianceSeverity _severity;
    protected Enum? _successTag;
    protected Enum? _incomplianceTag;

    public abstract Template WithSeverity(IncomplianceSeverity severity);
    public abstract Template WithSuccessTag(Enum successTag);
    public abstract Template WithIncomplianceTag(Enum incomplianceTag);
}

public sealed class EvaluationTemplate<TSubject> : Template
{
    private EvaluationPredicate<TSubject> _predicate;
    
    public EvaluationTemplate<TSubject> WithPredicate(EvaluationPredicate<TSubject> predicate)
    {
        _predicate = predicate;
        return this;
    }

    public override EvaluationTemplate<TSubject> WithSeverity(IncomplianceSeverity severity)
    {
        _severity = severity;
        return this;
    }

    public override EvaluationTemplate<TSubject> WithSuccessTag(Enum successTag)
    {
        _successTag = successTag;
        return this;
    }

    public override EvaluationTemplate<TSubject> WithIncomplianceTag(Enum incomplianceTag)
    {
        _incomplianceTag = incomplianceTag;
        return this;
    }

    public Evaluation<TSubject> Build()
    {
        ThrowIfNotRequiredFieldsProvided();

        return (TSubject subject, in EvaluationState state) =>
        {
            if (_predicate.Invoke(subject))
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

    private void ThrowIfNotRequiredFieldsProvided()
    {
        if (_predicate is null) throw new InvalidOperationException("predicate must be provided");

        if (this is { _severity: not IncomplianceSeverity.Alert, _severity: not IncomplianceSeverity.Error })
            throw new InvalidOperationException("severity must be provided");
    }
}