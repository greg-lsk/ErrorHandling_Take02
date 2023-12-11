using ConsoleApp.Core.Entities;
using ConsoleApp.Application.Evaluations;

using ErrorHandling.Drafts.PipelineBuilders;
using ErrorHandling.Drafts.Pipelining.YieldDelegates.Void;
using ErrorHandling.Drafts.Pipelining.YieldDelegates.Generic.Contsructive;


namespace ConsoleApp.Application.Drafts.Pipelines;

public class PersonPipe
{
    public static CtorPipe<string, string, Person> Create => 
        CtorPipe.WithSignature<string, string, Person>()
                .GuardFirstArgument(StringEvaluation.IsValid)
                .GuardSecondArgument(StringEvaluation.IsValid)
                .ForAction((firstName, lastName) => new Person(firstName, lastName))
                .Build();

    public static VoidPipe<Person, NameSelector, string> Rename =>
        VoidPipes.WithSignature<Person, NameSelector, string>()
                 .GuardThirdArgument(StringEvaluation.IsValid)
                 .ForAction((person, selector, newValue) => person.Rename(selector, newValue))
                 .Build();
}