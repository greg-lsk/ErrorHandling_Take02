using ErrorHandling;

namespace ConsoleApp.ValueTypes;

public enum CreateNameFlags
{
    NameStringValueIsEmpty,
    NameStringValueMaxLengthExceeded,
    NameStringValueStartsWithLowerCaseChar
}

public partial class Incompliance
{
    public static readonly IncomplianceRecord<string> NameIsEmpty = new
    (
        IncomplianceDelegate.StringIsEmpty,
        CreateNameFlags.NameStringValueIsEmpty,
        IncomplianceSeverity.Fatal
    );

    public static readonly IncomplianceRecord<string> NameStartsWithLowerCase = new
    (
        IncomplianceDelegate.StringStartsWithLowerCase,
        CreateNameFlags.NameStringValueStartsWithLowerCaseChar,
        IncomplianceSeverity.Error
    );

    public static readonly IncomplianceRecord<string, int> NameExceedsLength = new
    (
        IncomplianceDelegate.StringExceedsLength,
        CreateNameFlags.NameStringValueMaxLengthExceeded,
        IncomplianceSeverity.Error
    );
}