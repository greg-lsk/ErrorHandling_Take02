using ErrorHandling;
using ErrorHandling.Predicates;
using ConsoleApp.Core.ValueTypes;


namespace ConsoleApp.Application.ErrorConfig.ForName;

public static class NameEvaluation
{
    public static readonly Evaluation<Name> IsNotNull =
        EvaluationFor<Name>.WithPredicate(GenericPredicates.IsNotNull)
                           .WithSeverity(IncomplianceSeverity.Error)
                           .WithIncomplianceTag(NameTags.NullReference)
                           .Build();

    public static readonly Evaluation<Name> IsNotEmpty =
        EvaluationFor<Name>.WithPredicate(n => !n.IsEmpty)
                           .WithSeverity(IncomplianceSeverity.Error)
                           .WithIncomplianceTag(NameTags.Empty)
                           .Build();

    public static readonly Evaluation<Name> WithinLength =
        EvaluationFor<Name>.WithPredicate(n => n.Length < Name.MaxLength)
                           .WithSeverity(IncomplianceSeverity.Error)
                           .WithIncomplianceTag(NameTags.ExceedsLength)
                           .Build();

    public static readonly Evaluation<Name> StartsWithUpperCase =
        EvaluationFor<Name>.WithPredicate(n => n.StartsWithUpperCase)
                           .WithSeverity(IncomplianceSeverity.Error)
                           .WithIncomplianceTag(NameTags.StartsWithLowerCase)
                           .Build();

    public static readonly Evaluation<Name> IsValid =
        EvaluationFor<Name>.Sequencial()
                           .WithShortCircutEvaluations(IsNotNull,
                                                       IsNotEmpty)
                           .WithRegularEvaluations(WithinLength,
                                                   StartsWithUpperCase)
                           .WithIncomplianceTag(NameTags.Invalid)
                           .Build();
}