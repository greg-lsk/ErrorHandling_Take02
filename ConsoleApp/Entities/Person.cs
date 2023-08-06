using ConsoleApp.ValueTypes;
using ErrorHandling.Public;


namespace ConsoleApp.Entities;

public class Person
{
    public Name FirstName { get; private set; }
    public Name LastName { get; private set; }


    public static void Create(IResult<Name> firstName, IResult<Name> lastName)
    {
    }
}