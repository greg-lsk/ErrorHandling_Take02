using ConsoleApp.Core.Entities;
using ConsoleApp.Core.ValueTypes;

using ErrorHandling.ResultUtilities;
using ErrorHandling.Drafts.PipelineBuilders;
using ErrorHandling.Drafts.Pipelining.YieldDelegates.Void;
using ErrorHandling.Drafts.Pipelining.YieldDelegates.Generic.Contsructive;


namespace ConsoleApp.Application.Drafts.Pipelines;

public class PersonActions
{
    public static CtorPipe<string, string, Person> Create => 
        CtorPipe.WithSignature<string, string, Person>()
                .EvaluateFirstArgument(StringEvaluation.IsValid)
                .EvaluateSecondArgument(StringEvaluation.IsValid)
                .ForAction((firstName, lastName) => new Person(firstName, lastName))
                .Build();

    public static VoidPipe<Person, StructSelector<Person, Name>, string> Rename =>
        VoidPipes.WithSignature<Person, StructSelector<Person, Name>, string>()
                 .EvaluateThirdArgument(StringEvaluation.IsValid)
                 .ForAction((person, selector, newValue) => person.Rename(selector, newValue))
                 .Build();
}