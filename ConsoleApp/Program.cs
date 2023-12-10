using Microsoft.Extensions.Logging;

using ErrorHandling;
using ErrorHandling.Predicates;
using ConsoleApp.Core.ErrorConfig.ForName;


EvaluationConfig evaluationConfig = new();

using (var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole()))
{
    evaluationConfig.Logging(() => (loggerFactory, 6));

    /*    var person = Person.Create("Greg", "Alm");

        person.ActUpon(p => p.Rename(p => ref p.FirstName, "Gre"))
              .ActUpon(p => p.Rename(p => ref p.LastName, "allman"))
              .ActUpon(p => p.Print());*/


    var ev = EvaluationState.Init<string>();
    string name = "Gregory";

    StringEvaluation.IsValid(name, in ev);
    
    

    
}

internal class StringEvaluation
{
    internal readonly static Evaluation<string> IsNotNull 
        = EvaluationFor<string>.WithPredicate(GenericPredicates.IsNotNull)
                               .WithSeverity(IncomplianceSeverity.Error)
                               .WithIncomplianceTag(NameTags.NullReference)
                               .Build();

    internal readonly static Evaluation<string> IsNotEmpty = EvaluationFor<string>
        .WithPredicate(StringPredicates.IsNotEmpty)
        .WithSeverity(IncomplianceSeverity.Error)
        .WithIncomplianceTag(NameTags.Empty)
        .Build();

    internal readonly static Evaluation<string> StartsWithUpperCase = EvaluationFor<string>
        .WithPredicate(StringPredicates.StartsWithUpperCase)
        .WithSeverity(IncomplianceSeverity.Error)
        .WithIncomplianceTag(NameTags.StartsWithLowerCase)
        .Build();

    internal readonly static Evaluation<string> WithinLength = EvaluationFor<string>
        .WithPredicate(s => StringPredicates.WithinLength(s, 5))
        .WithSeverity(IncomplianceSeverity.Error)
        .WithIncomplianceTag(NameTags.ExceedsLength)
        .Build();

    internal readonly static Evaluation<string> IsValid = EvaluationFor<string>
        .Sequencial()
        .WithShortCircutEvaluations(IsNotNull,
                                    IsNotEmpty)
        .WithRegularEvaluations(StartsWithUpperCase,
                                WithinLength)
        .WithSeverity(IncomplianceSeverity.Error)
        .WithSuccessTag(NameTags.NullReference)
        .WithIncomplianceTag(NameTags.Invalid)
        .Build();     
}