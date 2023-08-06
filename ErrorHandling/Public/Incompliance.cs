namespace ErrorHandling.Public;

public class Incompliance
{
    public static bool StringIsEmpty(string param) => param == string.Empty;
    public static bool StringExceedsLength(string param, int length) => param.Length > length;
    public static bool StringStartsWithLower(string param) => char.IsLower(param[0]);
}