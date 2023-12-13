using ErrorHandling.ResultUtilities;

namespace ErrorHandling;

public class VoidResult : IResult
{
    public ResultReport? Report { get; private set; }

    public bool IsValid => Report is null;


    internal VoidResult() => Report = null;
    internal VoidResult(ResultReport report) => Report = report;
}