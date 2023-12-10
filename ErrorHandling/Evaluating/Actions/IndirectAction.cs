using ErrorHandling.Rule;
using ErrorHandling.Reporting;


namespace ErrorHandling.Evaluating.Actions;

internal static class IndirectAction<TSubject, TProperty>
{
    internal readonly static EvaluationAction<TSubject> Singular = (subject, rule, report, behaviour)
        => EvaluationCenter.Evaluate((rule as IndirectRule<TSubject, TProperty>)!.Selector(subject),
                                     (rule.Criterion as Func<TProperty, bool>)!,
                                     report,
                                     behaviour,
                                     rule.IncomplianceTag,
                                     rule.IncomplianceSeverity);
        

    internal readonly static EvaluationAction<TSubject> Sequencial = (subject, rule, report, behaviour)
        => EvaluationCenter.Evaluate((rule as IndirectRule<TSubject, TProperty>)!.Selector(subject),
                                     (rule.Criterion as RuleSequence<TProperty>)!,
                                     report,
                                     behaviour,
                                     rule.IncomplianceTag,
                                     rule.IncomplianceSeverity);
}