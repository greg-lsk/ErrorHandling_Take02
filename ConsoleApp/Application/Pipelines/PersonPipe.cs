using ConsoleApp.Core.Entities;
using ConsoleApp.Application.Evaluations;

using ErrorHandling.Drafts.Pipelining;
using ErrorHandling.Drafts.PipelineBuilders;


namespace ConsoleApp.Application.Pipelines;

public class PersonPipe
{
    public static ResultPipe<string, string, Person> Create =>
        Pipe.ForResult<Person>()
            .WithParamTypes<string, string>()
            .GuardFirstArgument(StringEvaluation.IsValid)
            .GuardSecondArgument(StringEvaluation.IsValid)
            .ForAction((firstName, lastName) => new Person(firstName, lastName))
            .Build();

    public static VoidPipe<Person, NameSelector, string> Rename =>
        Pipe.WithParamTypes<Person, NameSelector, string>()
            .GuardThirdArgument(StringEvaluation.IsValid)
            .ForAction((person, selector, newValue) => person.Rename(selector, newValue))
            .Build();
}