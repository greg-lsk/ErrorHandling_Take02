using ErrorHandling.Evaluating.Actions;


namespace ErrorHandling.Rule;

public abstract class DomainRule
{
    internal readonly object Criterion;

    internal readonly Enum IncomplianceTag;
    internal readonly IncomplianceSeverity IncomplianceSeverity;


    internal DomainRule(object criterion,
                        Enum incomplianceTag,
                        IncomplianceSeverity incomplianceSeverity)
    {
        Criterion = criterion;
        IncomplianceTag = incomplianceTag;
        IncomplianceSeverity = incomplianceSeverity;
    }
}

internal class DirectRule<TSubject> : DomainRule, IEvaluationActionCarrier<TSubject>
{
    public EvaluationAction<TSubject> Action => EvaluationActionProvider.Get(this);


    internal DirectRule(object criterion,
                        Enum incomplianceTag,
                        IncomplianceSeverity incomplianceSeverity)
        : base(criterion, incomplianceTag, incomplianceSeverity) { }
}

internal class IndirectRule<TSubject, TProperty> : DomainRule, IEvaluationActionCarrier<TSubject>
{
    internal readonly Func<TSubject, TProperty> Selector;
    public EvaluationAction<TSubject> Action => EvaluationActionProvider.Get(this);


    internal IndirectRule(object criterion,
                          Enum incomplianceTag,
                          IncomplianceSeverity incomplianceSeverity,
                          Func<TSubject, TProperty> selector) :
        base(criterion, incomplianceTag, incomplianceSeverity)
    {
        Selector = selector;
    }
}