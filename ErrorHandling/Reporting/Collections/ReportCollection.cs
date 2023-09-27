namespace ErrorHandling.Reporting.Collections;

internal readonly struct ReportCollection
{
    private readonly List<int> _reportLinks;
    private readonly List<EvaluationReport> _reports;

    internal readonly int Count => _reports.Count;

    internal readonly EvaluationReport this[int index]  => _reports[index];
    

    internal ReportCollection(EvaluationReport initialReport)
    {
        _reportLinks = new() { 0 };
        _reports = new() { initialReport };
    }


    internal int Append(ReportCollection reportCollection)
    {
        _reportLinks.Add(Count);
        _reports.AddRange(reportCollection._reports);
        
        return Count - 1;
    }

    internal void Print()
    {
        foreach (var report in _reports) { report.Print(); }
    }
}