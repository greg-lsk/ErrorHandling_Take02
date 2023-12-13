using ConsoleApp.Core.ValueTypes;


namespace ConsoleApp.Core.Entities;

public delegate ref Name NameSelector(Person entity);
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


    public void Rename(NameSelector selector, string newValue)
        =>  selector.Invoke(this) = new Name(newValue);
    
    public void Print() => Console.WriteLine($"{_firstName} {_lastName}");
}