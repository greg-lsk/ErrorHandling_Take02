using ConsoleApp.Core.Entities;
using ConsoleApp.Application.Evaluations;
using ErrorHandling.Drafts.PipelineBuilders;
using ErrorHandling.ResultUtilities;


namespace ConsoleApp.Application.Pipelines;

public class PersonActions
{
    public static Result<Person> Create(string firstName, string lastName) =>
        ResultPipe.Init()
            .Precondition(firstName, StringEvaluation.IsValid)
            .Precondition(lastName, StringEvaluation.IsValid)
            .ForAction(() => new Person(firstName, lastName));
    
    public static VoidResult Rename(Person person, NameSelector selector, string newValue) =>
        ResultPipe.Init()
            .Precondition(newValue, StringEvaluation.IsValid)
            .ForAction(() => person.Rename(selector, newValue));
}