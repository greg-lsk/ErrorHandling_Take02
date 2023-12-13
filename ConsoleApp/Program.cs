using Microsoft.Extensions.Logging;

using ErrorHandling;
using ConsoleApp.Application.Pipelines;


EvaluationConfig evaluationConfig = new();

using (var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole()))
{
    evaluationConfig.Logging(() => (loggerFactory, 6));

    string firstName = "Gregory";
    string lastName = "Liaskas";

    var person = PersonActions.Create(firstName, lastName);

    PersonActions.Rename(person, p => ref p.FirstName, "Gregg");
}