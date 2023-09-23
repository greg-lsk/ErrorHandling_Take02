using ErrorHandling.Public;

namespace ErrorHandling.Core.ErrorReporting;


internal struct ReportIndex
{
    internal int evaluationIndex = -1;
    internal int evaluatorIndex = -1;

    public ReportIndex() { }
}

internal class EvaluationReport : IReport
{
    private readonly EvaluationInfo _callerInfo;
    private readonly List<EvaluatorReport> _report;

    internal bool HasErrors;


    internal EvaluationReport(string callerFilePath,
                              string callerMemberName,
                              int callerLineNumber)
    {
        _callerInfo = new(callerFilePath, callerMemberName, callerLineNumber);
        _report = new();
    }


    internal void Add(ref ReportIndex index, EvaluationReport report)
    {

    }
    internal void Add(ref ReportIndex index, int callerLineNumber)
    {
        index.evaluationIndex = _report.Count;

        var report = new EvaluatorReport(callerLineNumber);
        _report.Insert(index.evaluationIndex, report);
    }
    internal void Add(ref ReportIndex index, Enum flag, IncomplianceSeverity severity)
    {
        index.evaluatorIndex = _report[index.evaluationIndex].Count;

        var report = new FlagReport(flag, severity);
        _report[index.evaluationIndex].Add(report);

        switch (severity)
        {
            case IncomplianceSeverity.Error:
            case IncomplianceSeverity.Fatal:
                HasErrors = true;
                break;
        }
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