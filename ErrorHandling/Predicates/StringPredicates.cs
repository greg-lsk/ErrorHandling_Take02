namespace ErrorHandling.Predicates;

public partial class StringPredicates
{
    public static bool IsEmpty(string subject) => subject == string.Empty;
    public static bool IsNotEmpty(string subject) => subject != string.Empty;

    public static bool StartsWithLowerCase(string subject) => char.IsLower(subject[0]);
    public static bool StartsWithUpperCase(string subject) => char.IsUpper(subject[0]);

    public static bool WithinLength(string subject, int length) => subject.Length <= length;
    public static bool ExceedsLength(string subject, int length) => subject.Length > length;
}