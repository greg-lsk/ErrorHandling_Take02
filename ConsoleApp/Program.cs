using ConsoleApp.Entities;
using ConsoleApp.ValueTypes;


var firstName = Name.Create("Gregg");
var lastName = Name.Create("Mann");

var person = Person.Create(firstName, lastName);

person.ActUpon(p => p.Rename(p => ref p.FirstName, "Gre"))
      .ActUpon(p => p.Rename(p => ref p.LastName, "Man"))
      .ActUpon(p => p.Print());