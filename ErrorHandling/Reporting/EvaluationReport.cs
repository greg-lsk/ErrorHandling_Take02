using ErrorHandling.Reporting.Collections;


namespace ErrorHandling.Reporting;

internal class EvaluationReport
{
    internal Guid ReportId { get; init; }
    internal List<Guid>? externalReports;

    private int _linksProvided;
    private List<FlagCollection>? _flags;

    internal int NextLink => _linksProvided++;
    internal bool HasErrors => _flags is not null;


    internal EvaluationReport() => ReportId = Guid.NewGuid();


    internal void LogIncompliance(ref int reportLink, Enum flag, IncomplianceSeverity severity)
    {
        switch (Behaviour(reportLink))
        {
            case (AddAction.CreateList):
                _flags = new() { new(flag, severity) };
                reportLink = _flags.Count - 1;
                break;

            case (AddAction.IndexedAdd):
                _flags![reportLink].Add(flag, severity);
                break;

            case (AddAction.NewFlagCollection):
                _flags!.Add(new(flag, severity));
                reportLink = _flags.Count - 1;
                break;
        }
    }

    internal void LogExternal(EvaluationReport report)
    {
        switch(_flags, report._flags)
        {
            case (null, null): break;

            case (_, null): break;

            case (null, _):
                _flags = new();
                _flags = report._flags;
                UpdateExternalReports(report);
                break;

            case (_, _):
                _flags.AddRange(report._flags);
                UpdateExternalReports(report);
                break;
        }
    }

    internal bool EvaluationYieldedErrors(int reportLink) 
        => _flags is not null && reportLink <= _flags.Count;


    private enum AddAction
    {
        CreateList,
        NewFlagCollection,
        IndexedAdd
    }
    private AddAction Behaviour(int reportLink)
    {
        if (_flags is null) return AddAction.CreateList;

        return reportLink.CompareTo(_flags.Count) switch
        {
            1 => AddAction.NewFlagCollection,
            _ => AddAction.IndexedAdd 
        };
    }
    private void UpdateExternalReports(EvaluationReport report)
    {
        if(externalReports is not null)
        {
            externalReports.Add(report.ReportId);
            return;
        }

        externalReports = new() { report.ReportId };
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