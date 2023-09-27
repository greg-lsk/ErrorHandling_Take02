using ConsoleApp.ValueTypes;
using ErrorHandling;
using ErrorHandling.Evaluating;


namespace ConsoleApp.Entities;

public class Person
{
    internal Name FirstName;
    internal Name LastName;


    internal Person(Name firstName, Name lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }


    public static Result<Person> Create(Result<Name> firstName,
                                        Result<Name> lastName)
    {
        var evaluation = Evaluation.Init();

        return evaluation.Evaluate(firstName)
                         .Evaluate(lastName)
                         .YieldResult<Person>(() => new(firstName.Value, lastName.Value));
    }
}