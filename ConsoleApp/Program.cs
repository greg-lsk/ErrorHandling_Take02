using Microsoft.Extensions.Logging;

using ConsoleApp.Entities;
using ErrorHandling;


EvaluationConfig evaluationConfig = new();

using (var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole()))
{
    evaluationConfig.Logging(() => (loggerFactory, 6));

    var person = Person.Create("Greg", "Alm");

    person.ActUpon(p => p.Rename(p => ref p.FirstName, "Gre"))
          .ActUpon(p => p.Rename(p => ref p.LastName, "allman"))
          .ActUpon(p => p.Print());
}