using ErrorHandling.Drafts.ResultPipelining;

using ConsoleApp.Core.Entities;
using ConsoleApp.Application.Evaluations;
using ErrorHandling;


namespace ConsoleApp.Application.Pipelines;

public class PersonActions
{
    public Result<Person> Create(string firstName,
                                 string lastName)
        => ResultPipe.Initialize()
        .CheckPrecondition(firstName, StringEvaluation.IsValid)
        .CheckPrecondition(lastName, StringEvaluation.IsValid)
        .Execute(() => new Person(firstName, lastName));


    public VoidResult Rename(Person person,
                             NameSelector selector,
                             string newValue) 
        => ResultPipe.Initialize()
        .CheckPrecondition(person, PersonEvaluation.IsValid)
        .CheckPrecondition(newValue, StringEvaluation.IsValid)
        .Execute(() => person.Rename(selector, newValue));
}