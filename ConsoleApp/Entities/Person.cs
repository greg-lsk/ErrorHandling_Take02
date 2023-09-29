using ConsoleApp.ValueTypes;
using ErrorHandling.Evaluating;
using ErrorHandling.Result;


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
        evaluation.Evaluate(firstName, lastName);
                
        return evaluation.YieldResult<Person>(() => new(firstName.Value, lastName.Value));
    }
}