using ErrorHandling.Reporting.Abstract;


namespace ErrorHandling.Reporting;

internal class EvaluationReport : IdentifiableReport
{
    internal List<Guid>? externalReports;

    private int _linksProvided;

    internal int NextLink => _linksProvided++;
    internal bool HasErrors => Flags is not null;


    internal EvaluationReport() : base() { }


    internal void LogIncompliance(ref int reportLink, Enum flag, IncomplianceSeverity severity)
    {
        switch (Behaviour(reportLink))
        {
            case AddAction.CreateList:
                Flags = new() { new(flag, severity) };
                reportLink = Flags.Count - 1;
                break;

            case AddAction.IndexedAdd:
                Flags![reportLink].Add(flag, severity);
                break;

            case AddAction.NewFlagCollection:
                Flags!.Add(new(flag, severity));
                reportLink = Flags.Count - 1;
                break;
        }
    }

    internal void LogExternal(IdentifiableReport report)
    {
        MergeWith(report);

        if (report.Flags is null) return;

        if (externalReports is not null)
        {
            externalReports.Add(report.ReportId);
            return;
        }

        externalReports = new() { report.ReportId };
    }

    internal bool EvaluationYieldedErrors(int reportLink) 
        => Flags is not null && reportLink <= Flags.Count;


    private enum AddAction
    {
        CreateList,
        NewFlagCollection,
        IndexedAdd
    }
    private AddAction Behaviour(int reportLink)
    {
        if (Flags is null) return AddAction.CreateList;

        return reportLink.CompareTo(Flags.Count) switch
        {
            1 => AddAction.NewFlagCollection,
            _ => AddAction.IndexedAdd 
        };
    }
    

    internal string StringRep()
    {
        var str = $"[ID]:           {ReportId}";
        if (externalReports is not null)
        {
            foreach(var id in externalReports)
                str = $"{str}\n  -[ExternalErrors]{id}";
        }
        return str;
    }
}