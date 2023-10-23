using Microsoft.Extensions.Logging;

using ConsoleApp.Entities;
using ConsoleApp.ValueTypes;
using ErrorHandling;


EvaluationConfig evaluationConfig = new();

using (var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole()))
{
    evaluationConfig.Logging(() => (loggerFactory, 6));

    var person = Person.Create("Greg", "Allm");

    person.ActUpon(p => ref p.FirstName, Name.Change, "Gregg")
          .ActUpon(p => ref p.LastName, Name.Change, "allman")
          .ActUpon(p => p.Print());
}