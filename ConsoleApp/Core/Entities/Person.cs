using ConsoleApp.Core.ValueTypes;
using ErrorHandling.ResultUtilities;


namespace ConsoleApp.Core.Entities;

public class Person
{
    private Name _firstName;
    private Name _lastName;

    public ref Name FirstName => ref _firstName;
    public ref Name LastName => ref _lastName;


    internal Person(string firstName, string lastName)
    {
        _firstName = new(firstName);
        _lastName = new(lastName);
    }

    public void Rename(StructSelector<Person, Name> nameSelector,string newValue)
        =>  nameSelector.Invoke(this) = new Name(newValue);
    
    public void Print() => Console.WriteLine($"{_firstName} {_lastName}");
}