using ErrorHandling;
using ErrorHandling.Predicates;


namespace ConsoleApp.Application.Evaluations;

public class StringEvaluation
{
    public readonly static Evaluation<string> IsNotNull =
        EvaluationFor<string>.WithPredicate(GenericPredicates.IsNotNull)
                             .WithSeverity(IncomplianceSeverity.Error)
                             .Build();

    public readonly static Evaluation<string> IsNotEmpty =
        EvaluationFor<string>.WithPredicate(StringPredicates.IsNotEmpty)
                             .WithSeverity(IncomplianceSeverity.Error)
                             .Build();

    public readonly static Evaluation<string> StartsWithUpperCase =
        EvaluationFor<string>.WithPredicate(StringPredicates.StartsWithUpperCase)
                             .WithSeverity(IncomplianceSeverity.Error)
                             .Build();

    public readonly static Evaluation<string> WithinLength =
        EvaluationFor<string>.WithPredicate(s => StringPredicates.WithinLength(s, 5))
                             .WithSeverity(IncomplianceSeverity.Error)
                             .Build();

    public readonly static Evaluation<string> IsValid =
        EvaluationFor<string>.Sequencial()
                             .WithShortCircutEvaluations(IsNotNull,
                                                         IsNotEmpty)
                             .WithRegularEvaluations(StartsWithUpperCase,
                                                     WithinLength)
                             .WithSeverity(IncomplianceSeverity.Error)
                             .Build();
}