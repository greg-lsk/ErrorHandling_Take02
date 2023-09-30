using ConsoleApp.Entities;
using ConsoleApp.ValueTypes;


var firstName = Name.Create("Greg");
var lastName = Name.Create("Allm");

var person = Person.Create(firstName, lastName);

person.ActUpon(p => p.Rename(p => ref p.FirstName, "Gregg"))
      .ActUpon(p => p.Rename(p => ref p.LastName, "Man"))
      .ActUpon(p => p.Print());