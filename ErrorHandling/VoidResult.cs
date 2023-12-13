using ErrorHandling.ResultUtilities;

namespace ErrorHandling;

public class VoidResult : IResult
{
    public ResultReport? Report { get; private set; }

    public bool IsValid => Report is null;


    public VoidResult() => Report = null;
    public VoidResult(ResultReport report) => Report = report;
}