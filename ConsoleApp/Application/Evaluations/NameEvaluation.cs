using ErrorHandling;
using ErrorHandling.Predicates;
using ConsoleApp.Core.ValueTypes;


namespace ConsoleApp.Application.Evaluations;

public static class NameEvaluation
{
    public static readonly Evaluation<Name> IsNotNull =
        EvaluationFor<Name>.WithPredicate(GenericPredicates.IsNotNull)
                           .WithSeverity(IncomplianceSeverity.Error)
                           .Build();

    public static readonly Evaluation<Name> IsNotEmpty =
        EvaluationFor<Name>.WithPredicate(n => !n.IsEmpty)
                           .WithSeverity(IncomplianceSeverity.Error)
                           .Build();

    public static readonly Evaluation<Name> WithinLength =
        EvaluationFor<Name>.WithPredicate(n => n.Length < Name.MaxLength)
                           .WithSeverity(IncomplianceSeverity.Error)
                           .Build();

    public static readonly Evaluation<Name> StartsWithUpperCase =
        EvaluationFor<Name>.WithPredicate(n => n.StartsWithUpperCase)
                           .WithSeverity(IncomplianceSeverity.Error)
                           .Build();

    public static readonly Evaluation<Name> IsValid =
        EvaluationFor<Name>.Sequencial()
                           .WithShortCircutEvaluations(IsNotNull,
                                                       IsNotEmpty)
                           .WithRegularEvaluations(WithinLength,
                                                   StartsWithUpperCase)
                           .Build();
}