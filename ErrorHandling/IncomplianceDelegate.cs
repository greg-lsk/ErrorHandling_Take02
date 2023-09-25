namespace ErrorHandling;

public partial class IncomplianceDelegate
{
    public static bool StringIsEmpty(string param) => param == string.Empty;
    public static bool StringExceedsLength(string param, int length) => param.Length > length;
    public static bool StringStartsWithLowerCase(string param) => char.IsLower(param[0]);
}