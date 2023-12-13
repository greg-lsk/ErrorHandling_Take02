using Microsoft.Extensions.Logging;

using ErrorHandling;
using ConsoleApp.Application.Pipelines;
using ConsoleApp.Core.Entities;


PersonActions personActions = new();
EvaluationConfig evaluationConfig = new();

using (var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole()))
{
    evaluationConfig.Logging(() => (loggerFactory, 6));

    string firstName = "Gregory";
    string lastName = "Liaskas";

    var person = new Person(firstName, lastName);

    personActions.Rename(person, p => ref p.FirstName, "Gregg");
}