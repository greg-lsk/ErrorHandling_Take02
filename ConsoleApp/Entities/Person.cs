using ConsoleApp.ValueTypes;
using ErrorHandling.Evaluating;
using ErrorHandling.Result;


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
        var evaluation = Evaluation.Init();

        evaluation.Evaluate(firstName, lastName);
        
        return evaluation.YieldResult<Person>(() => new(firstName.Value, lastName.Value));
    }

    public VoidResult Rename(StructSelector<Person, Name> selectionDelegate,
                             string param)
    {
        var evaluation = Evaluation.Init();

        var newName = Name.Create(param);
        evaluation.Evaluate(newName as IResult);

        return evaluation.YieldVoid(
            newName.Value.StringValue, 
            (sv) => selectionDelegate.Invoke(this) = new(sv));
    }

    public void Print() => Console.WriteLine($"{_firstName.StringValue}\n" +
                                             $"{_lastName.StringValue}");
}