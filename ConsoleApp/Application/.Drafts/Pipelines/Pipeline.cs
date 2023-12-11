using ConsoleApp.Core.Entities;
using ConsoleApp.Core.ValueTypes;

using ErrorHandling.ResultUtilities;
using Void = ErrorHandling.Drafts.Pipelining.YieldDelegates.Void;
using VoidBuild = ErrorHandling.Drafts.PipelineBuilders.VoidYield;
using Ctor = ErrorHandling.Drafts.Pipelining.YieldDelegates.Generic.Contsructive;
using CtorBuild = ErrorHandling.Drafts.PipelineBuilders.GenericYield.Constructive;


namespace ConsoleApp.Application.Drafts.Pipelines;

public class PersonActions
{
    public static Ctor.Yield<Person, string, string> Create => new 
    CtorBuild.PipelineBuilder<Person, string, string>()
        .EvaluateFirstArgument(StringEvaluation.IsValid)
        .EvaluateSecondArgument(StringEvaluation.IsValid)
        .ForAction((firstName, lastName) => new Person(firstName, lastName))
        .Build();

    public static Void.Yield<Person, StructSelector<Person, Name>, string> Rename =>
    new VoidBuild.PipelineBuilder<Person, StructSelector<Person, Name>, string>()
        .EvaluateFirstArgument()
        .EvaluateSecondArgument()
        .EvaluateThirdArgument(StringEvaluation.IsValid)
        .ForAction((person, selector, newValue)=>person.Rename(selector, newValue))
        .Build();
}