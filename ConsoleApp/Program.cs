using ConsoleApp.Entities;
using ConsoleApp.ValueTypes;
using ErrorHandling;
using Microsoft.Extensions.Logging;



using (var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole()))
{
    EvaluationConfig.Logging(() => loggerFactory);

    var person = Person.Create("Gre", "Allm");

    person.ActUpon(p => ref p.FirstName, Name.Change, "gregg")
          .ActUpon(p => ref p.LastName, Name.Change, "allman")
          .ActUpon(p => p.Print());
}