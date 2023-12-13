using ErrorHandling;
using ErrorHandling.ResultUtilities;
using ErrorHandling.Drafts.ResultPipelining;

using ConsoleApp.Core.Entities;
using ConsoleApp.Application.Evaluations;


namespace ConsoleApp.Application.Pipelines;

public class PersonActions
{
    public static Result<Person> Create(string firstName,
                                        string lastName) 
        => ResultPipe.Initialize()
        .CheckPrecondition(firstName, StringEvaluation.IsValid)
        .CheckPrecondition(lastName, StringEvaluation.IsValid)
        .Execute(() => new Person(firstName, lastName));


    public static VoidResult Rename(Result<Person> result,
                                    NameSelector selector,
                                    string newValue) 
        => ResultPipe.Initialize()
        .CheckPrecondition(result, ResultEvaluation<Person>.IsValid)
        .CheckPrecondition(newValue, StringEvaluation.IsValid)
        .Execute(() => (result.Value!).Rename(selector, newValue));
}

public class ResultEvaluation<T>
{
    public static readonly Evaluation<Result<T>> IsValid =
        EvaluationFor<Result<T>>.WithPredicate(r => r.IsValid)
                                .WithIncomplianceTag(IncomplianceSeverity.Error)
                                .Build();
}