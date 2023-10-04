using ErrorHandling.Reporting.Abstract;
using ErrorHandling.Reporting.Collections;


namespace ErrorHandling.ResultUtilities;

public class ResultReport : IdentifiableReport
{
    internal ResultReport() : base() { }

    internal ResultReport(Guid id, List<FlagCollection> flags)
    {
        ReportId = id;
        Flags = flags;
    }
}