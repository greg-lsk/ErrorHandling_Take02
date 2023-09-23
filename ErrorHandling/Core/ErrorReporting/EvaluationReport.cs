namespace ErrorHandling.Core.ErrorReporting;

internal class EvaluationReport : IReport
{
    private readonly EvaluationInfo _callerInfo;
    private readonly List<IReport> _report;


    internal EvaluationReport(string callerFilePath,
                              string callerMemberName,
                              int callerLineNumber)
    {
        _callerInfo = new(callerFilePath, callerMemberName, callerLineNumber);
        _report = new();
    }


    internal void Add(IReport report, out int addedAt)
    {
        _report.Add(report);
        addedAt = _report.Count - 1;
    }
    internal void Add(IReport report, int addTo)
    {
        var at = _report[addTo];
        ((EvaluatorReport)at).Add(report);
    }


    public override string ToString()
    {
        var returnValue = "Evaluation Event Details" + "\n" + _callerInfo.ToString() + "\n";

        for(int i=0; i<_report.Count; ++i)
            returnValue += "     " + _report[i].ToString() + "\n";

        Console.WriteLine(returnValue);

        return returnValue;
    }
}