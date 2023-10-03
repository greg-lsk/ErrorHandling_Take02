using ConsoleApp.Entities;
using ConsoleApp.ValueTypes;

var person = Person.Create("Gre", "Allm");

person.ActUpon(p => ref p.FirstName, Name.Change, "Greg")
      .ActUpon(p => ref p.LastName, Name.Change, "Allman")
      .ActUpon(p => p.Print());