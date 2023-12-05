using ConsoleApp.Core.ValueTypes;
using ErrorHandling.Evaluating;
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


    public static Result<Person> Create(string firstName, string lastName)
    {
        var evaluation = Evaluation.Init<Person>();

        evaluation.Evaluate(IncomplianceChain.InvalidName,
                            AttachingBehaviour.Accumulative,
                            firstName, lastName);

        return evaluation.YieldResult(firstName,
                                      lastName,
                                      (fn, ln) => new Person(fn, ln));
    }


    public VoidResult Rename(StructSelector<Person, Name> nameSelector,
                             string newValue)
    {
        var evaluation = Evaluation.Init<Person>();

        evaluation.Evaluate(newValue,
                            IncomplianceChain.InvalidName,
                            AttachingBehaviour.Accumulative);

        return evaluation.YieldVoid(nameSelector,
                                    newValue,
                                    (ns, nv) => ns.Invoke(this) = new Name(nv));
    }

    public void Print() => Console.WriteLine($"{_firstName.StringValue}\n" +
                                             $"{_lastName.StringValue}");
}