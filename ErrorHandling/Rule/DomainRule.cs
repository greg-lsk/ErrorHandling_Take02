namespace ErrorHandling.Rule;

internal enum EvaluationLogic
{
    SingularDirect,
    SequentialDirect,

    SingularIndirect,
    SequentialIndirect
}

public abstract class DomainRule
{
    internal readonly object Criterion;

    internal readonly Enum IncomplianceTag;
    internal readonly IncomplianceSeverity IncomplianceSeverity;

    internal abstract EvaluationLogic EvaluationLogic { get; }


    internal DomainRule(object criterion,
                       Enum incomplianceTag,
                       IncomplianceSeverity incomplianceSeverity)
    {
        Criterion = criterion;
        IncomplianceTag = incomplianceTag;
        IncomplianceSeverity = incomplianceSeverity;
    }
}

internal class DirectRule<TSubject> : DomainRule
{
    public DirectRule(object criterion,
                      Enum incomplianceTag,
                      IncomplianceSeverity incomplianceSeverity)
        : base(criterion, incomplianceTag, incomplianceSeverity) { }


    internal override EvaluationLogic EvaluationLogic => Criterion switch
    {
        Func<TSubject, bool>   => EvaluationLogic.SingularDirect ,
        RuleSequence<TSubject> => EvaluationLogic.SequentialDirect,
        _ => throw new Exception()
    };
}

internal class IndirectRule<TSubject, TProperty> : DomainRule
{
    internal Func<TSubject, TProperty> Selector;

    public IndirectRule(object criterion,
                        Enum incomplianceTag,
                        IncomplianceSeverity incomplianceSeverity,
                        Func<TSubject, TProperty> selector) :
        base(criterion, incomplianceTag, incomplianceSeverity)
    {
        Selector = selector;
    }

    internal override EvaluationLogic EvaluationLogic => Criterion switch
    {
        Func<TProperty, bool>   => EvaluationLogic.SingularIndirect,
        RuleSequence<TProperty> => EvaluationLogic.SequentialIndirect,
        _ => throw new Exception()
    };
}