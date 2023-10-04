namespace ErrorHandling.ResultUtilities;

public interface IResult
{
    public bool IsValid { get; }
    internal ResultReport? Report { get; }
}