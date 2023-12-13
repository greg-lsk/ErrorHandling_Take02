namespace ErrorHandling.ResultUtilities;

internal interface IResult
{
    internal bool IsValid { get; }
    internal ResultReport? Report { get; }
}