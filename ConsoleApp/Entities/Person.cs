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

    internal Person(string firstName, string lastName)
    {
        _firstName = new(firstName);
        _lastName = new(lastName);
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
        evaluation.Evaluate(firstName)
                  .CaptureAll(EvaluationChain.InvalidName)
                  .Evaluate(lastName)
                  .CaptureAll(EvaluationChain.InvalidName);
        
        return evaluation.YieldResult(firstName,
                                      lastName,
                                      (fn, ln) => new Person(fn, ln));
    }

    public void Print() => Console.WriteLine($"{_firstName.StringValue}\n" +
                                             $"{_lastName.StringValue}");
}