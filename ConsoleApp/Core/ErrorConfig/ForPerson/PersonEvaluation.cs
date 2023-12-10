using ErrorHandling;
using ErrorHandling.Predicates;
using ConsoleApp.Core.Entities;
using ConsoleApp.Core.ErrorConfig.ForName;


namespace ConsoleApp.Core.ErrorConfig.ForPerson;

public class PersonEvaluation 
{
    public static readonly Evaluation<Person> IsNotNull = 
        EvaluationFor<Person>.WithPredicate(GenericPredicates.IsNotNull)
                             .WithSeverity(IncomplianceSeverity.Error)
                             .Build();

    public static readonly Evaluation<Person> HasValidFirstName = 
        EvaluationFor<Person>.WithSelection(p => p.FirstName, NameEvaluation.IsValid)
                             .WithSeverity(IncomplianceSeverity.Error)
                             .Build();

    public static readonly Evaluation<Person> HasValidLastName = 
        EvaluationFor<Person>.WithSelection(p => p.LastName, NameEvaluation.IsValid)
                             .WithSeverity(IncomplianceSeverity.Error)
                             .Build();

    public static readonly Evaluation<Person> IsValid = 
        EvaluationFor<Person>.Sequencial()
                             .WithShortCircutEvaluations(IsNotNull)
                             .WithRegularEvaluations(HasValidFirstName,
                                                     HasValidLastName)
                             .WithSeverity(IncomplianceSeverity.Error)
                             .Build();
}