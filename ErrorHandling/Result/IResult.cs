using ErrorHandling.Reporting;

namespace ErrorHandling.Result;

public interface IResult
{
    public bool IsValid { get; }
    internal ResultReport? Report { get; }
}