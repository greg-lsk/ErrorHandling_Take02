namespace ErrorHandling.Core.ErrorReporting;

internal class EvaluatorReport : IReport
{
    private readonly int _callerLineNumber;
    private List<IReport>? _report;


    internal EvaluatorReport(int callerLineNumber) => _callerLineNumber = callerLineNumber;


    internal void Add(IReport report)
    {
        if(_report is null)
        {
            _report = new() { report };
            return;
        }

        _report.Add(report);
    }

    public override string ToString()
    {
        var returnValue = "Subject evaluated at [Line]:" + _callerLineNumber + "\n";

        if (_report is null)
        {
            returnValue += "    -OK\n";
            return returnValue;
        }

        for (int i = 0; i < _report.Count; ++i)
            returnValue += "    " + _report[i].ToString() + "\n";

        return returnValue;
    }
}