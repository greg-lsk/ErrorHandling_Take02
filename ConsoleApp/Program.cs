using ConsoleApp.Entities;


var person = Person.Create("Gregg", "Allman");

person.ActUpon(p => p.Rename(p => ref p.FirstName, "Gre"))
      .ActUpon(p => p.Rename(p => ref p.LastName, "Man"))
      .ActUpon(p => p.Print());