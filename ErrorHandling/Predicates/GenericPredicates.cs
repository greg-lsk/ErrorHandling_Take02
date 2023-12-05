namespace ErrorHandling.Predicates;

public class GenericPredicates
{
    public static bool IsNull<TSubject>(TSubject subject) => subject == null;
    public static bool IsNotNull<TSubject>(TSubject subject) => subject != null;
}