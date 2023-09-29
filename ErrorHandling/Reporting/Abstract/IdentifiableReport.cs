using ErrorHandling.Reporting.Collections;

namespace ErrorHandling.Reporting.Abstract;


public abstract class IdentifiableReport
{
    internal Guid ReportId { get; init; }
    internal List<FlagCollection>? Flags { get; set; }


    internal IdentifiableReport() => ReportId = Guid.NewGuid();


    internal void MergeWith(IdentifiableReport report)
    {
        switch (Flags, report.Flags)
        {
            case (null, null): break;

            case (_, null): break;

            case (null, _):
                Flags = new();
                Flags = report.Flags;
                break;

            case (_, _):
                Flags.AddRange(report.Flags);
                break;
        }
    }
}