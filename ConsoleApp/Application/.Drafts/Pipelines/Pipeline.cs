using ConsoleApp.Core.Entities;
using ConsoleApp.Core.ValueTypes;

using ErrorHandling;
using ErrorHandling.ResultUtilities;
using Void = ErrorHandling.Drafts.Pipelining.YieldDelegates.Void;
using Generic = ErrorHandling.Drafts.Pipelining.YieldDelegates.Generic;
using Ctor = ErrorHandling.Drafts.Pipelining.YieldDelegates.Generic.Contsructive;
using ErrorHandling.Drafts.PipelineBuilders;


namespace ConsoleApp.Application.Drafts.Pipelines;

public class PersonActions
{

    public static Ctor.Yield<Person, string, string> Create =>
    
    new PipelineBuilder<Person, string, string>()
        .EvaluateFirstArgumentWith(StringEvaluation.IsValid)
        .EvaluateSecondArgumentWith(StringEvaluation.IsValid)
        .OnSuccess((firstName, lastName) => new Person(firstName, lastName))
        .Build();
    
    
/*    {
        var state = EvaluationState.Init<Person>();

        Person? person;

        if (StringEvaluation.IsValid(name01, state) && StringEvaluation.IsValid(name02, state))
            person = new Person(name01, name02);

        person = null;

        return new Result<Person>(person);
    };*/

    public static Void.Yield<Person, StructSelector<Person, Name>, string> Rename =>
    (person, selector, newValue) =>
    {
        var state = EvaluationState.Init<Person>();

        if (StringEvaluation.IsValid(newValue, in state))
        {
            person.Rename(selector, newValue);
            return new VoidResult();
        }

        else return new VoidResult();
    };

}