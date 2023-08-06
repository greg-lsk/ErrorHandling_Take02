using ErrorHandling.Public;
using ErrorHandling.Core;
using ConsoleApp.SupervisorExtensions;

namespace ConsoleApp.ValueTypes;

public enum CreateNameFlags
{
    NameStringValueIsNull,
    NameStringValueIsEmpty,
    NameStringValueMaxLengthExceeded,
    NameStringValueStartsWithLowerCaseChar
}

public struct Name
{
    public const int MaxLength = 10;
    public string StringValue { get; set; }

    public static IResult<Name> Create(string stringValue) =>
        Supervision.Init()
        .Supervise(stringValue)
        .IfNullAttach(CreateNameFlags.NameStringValueIsNull)
        .CaptureAll()
            .Check(Incompliance.StringIsEmpty)
            .OnErrorAttach(CreateNameFlags.NameStringValueIsEmpty)
            .Check(Incompliance.StringExceedsLength, MaxLength)
            .OnErrorAttach(CreateNameFlags.NameStringValueMaxLengthExceeded)
            .Check(Incompliance.StringStartsWithLower)
            .OnErrorAttach(CreateNameFlags.NameStringValueStartsWithLowerCaseChar)
        .Finalize()
        .YieldResult<Name>()
        .Bind(() => new() { StringValue = stringValue });
}