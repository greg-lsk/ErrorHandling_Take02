using ErrorHandling;
using ConsoleApp.Core.ValueTypes;
using ErrorHandling.Predicates;
using ErrorHandling.Drafts;

namespace ConsoleApp.Core.ErrorConfig.ForName;

public static class NameEvaluation
{
    public static readonly Evaluation<Name> IsNotNull
        = Evaluation.Builder<Name>()
                    .WithPredicate(GenericPredicates.IsNotNull)
                    .WithSeverity(IncomplianceSeverity.Error)
                    .WithIncomplianceTag(NameTags.NullReference)
                    .Build();

    public static readonly Evaluation<Name> IsNotEmpty
        = Evaluation.Builder<Name>()
                    .WithPredicate(n => !n.IsEmpty)
                    .WithSeverity(IncomplianceSeverity.Error)
                    .WithIncomplianceTag(NameTags.Empty)
                    .Build();

    public static readonly Evaluation<Name> WithinLength
        = Evaluation.Builder<Name>()
                    .WithPredicate(n => n.Length < Name.MaxLength)
                    .WithSeverity(IncomplianceSeverity.Error)
                    .WithIncomplianceTag(NameTags.ExceedsLength)
                    .Build();

    public static readonly Evaluation<Name> StartsWithUpperCase
        = Evaluation.Builder<Name>()
                    .WithPredicate(n => n.StartsWithUpperCase)
                    .WithSeverity(IncomplianceSeverity.Error)
                    .WithIncomplianceTag(NameTags.StartsWithLowerCase)
                    .Build();

    public static readonly Evaluation<Name> IsValid
        = Evaluation.BatchBuilder<Name>()
                    .WithShortCircutEvaluations(IsNotNull, IsNotEmpty)
                    .WithRegularEvaluations(WithinLength, StartsWithUpperCase)
                    .WithIncomplianceTag(NameTags.Invalid)
                    .Build();
}