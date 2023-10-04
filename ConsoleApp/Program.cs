using ConsoleApp.Entities;
using ConsoleApp.ValueTypes;
using ErrorHandling.Reporting.Logging;
using Microsoft.Extensions.Logging;

EvaluationLogger.Configure(
    LoggerFactory.Create(builder => 
    {
        builder.AddConsole();
    }));

var person = Person.Create("Gre", "Allm");

person.ActUpon(p => ref p.FirstName, Name.Change, "Greg")
      .ActUpon(p => ref p.LastName, Name.Change, "allman")
      .ActUpon(p => p.Print());