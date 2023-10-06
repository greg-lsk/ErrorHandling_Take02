using ConsoleApp.Entities;
using ConsoleApp.ValueTypes;
using ErrorHandling;
using ErrorHandling.Reporting.CallStackInfo;
using Microsoft.Extensions.Logging;



using (var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole()))
{
    EvaluationConfig.Logging(() => loggerFactory);

    FlagPrefix.loggerProviderIndent = 6;
    FlagPrefix.Create();

    var person = Person.Create("Gre", "Allm");

    person.ActUpon(p => ref p.FirstName, Name.Change, "Gregg")
          .ActUpon(p => ref p.LastName, Name.Change, "allman")
          .ActUpon(p => p.Print());
}