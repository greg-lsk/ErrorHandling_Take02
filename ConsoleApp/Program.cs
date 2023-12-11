using Microsoft.Extensions.Logging;

using ErrorHandling;
using ConsoleApp.Application.Drafts.Pipelines;


EvaluationConfig evaluationConfig = new();

using (var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole()))
{
    evaluationConfig.Logging(() => (loggerFactory, 6));

    string firstName = "Gregory";
    string lastName = "Liaskas";

    var person = PersonPipe.Create(firstName, lastName);

    person.ActUpon(p => PersonPipe.Rename(p, p => ref p.FirstName, "Gregg"));
}