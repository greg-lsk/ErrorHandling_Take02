using ConsoleApp.ValueTypes;
using ErrorHandling.Evaluating;
using ErrorHandling.ResultUtilities;


namespace ConsoleApp.Entities;

public class Person
{
    private Name _firstName;
    private Name _lastName;

    public ref Name FirstName => ref _firstName;
    public ref Name LastName => ref _lastName;


    internal Person(Name firstName, Name lastName)
    {
        _firstName = firstName;
        _lastName = lastName;
    }


    public static Result<Person> Create(Result<Name> firstName,
                                        Result<Name> lastName)
    {
        var evaluation = Evaluation.Init<Person>();
        evaluation.Evaluate(firstName, lastName);
        
        return evaluation.YieldResult(firstName.Value,
                                      lastName.Value,
                                      (fn, ln) => new Person(fn, ln));
    }
    public static Result<Person> Create(string firstName, string lastName)
    {
        var evaluation = Evaluation.Init<Person>();

        var firstNameR = Name.Create(firstName);
        var lastNameR = Name.Create(lastName);

        evaluation.Evaluate(firstNameR, lastNameR);

        return evaluation.YieldResult(firstNameR.Value,
                                      lastNameR.Value,
                                      (fn, ln) => new Person(fn, ln));
    }

    public void Print() => Console.WriteLine($"{_firstName.StringValue}\n" +
                                             $"{_lastName.StringValue}");
}