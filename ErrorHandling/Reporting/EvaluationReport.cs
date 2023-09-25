using System.Text;
using ErrorHandling.Reporting.Collections;
using ErrorHandling.Reporting.CallStackInfo;


namespace ErrorHandling.Reporting;

internal class EvaluationReport
{
    private readonly EvaluationInfo _evaluationInfo;

    private readonly List<EvaluatorInfo> _evaluations;
    private readonly List<int> _flagLinks;
    private List<FlagCollection>? _flags;

    internal bool HasErrors;


    internal EvaluationReport(string callerFilePath,
                              string callerMethodName,
                              int callerLineNumber)
    {
        _evaluationInfo = new(callerFilePath, callerMethodName, callerLineNumber);

        _flagLinks = new() { };
        _evaluations = new();
    }


    internal void Insert(ref ReportIndex index, int callerLineNumber)
    {
        _flagLinks.Add(-1);
        _evaluations.Add(new(callerLineNumber));

        index.evaluationIndex = _evaluations.Count - 1;
    }

    internal void Insert(ref ReportIndex index, Enum flag, IncomplianceSeverity severity)
    {
        _flagLinks[index.evaluationIndex] = index.evaluationIndex;
        UpdateErrorStatus(severity);

        if (_flags is null)
        {
            _flags = new() { new(flag, severity) };
            return;
        }

        //CopingOfStructRequired: 2             
        var flags = _flags[index.evaluationIndex];
        flags.Add(flag, severity);
        _flags[index.evaluationIndex] = flags;
        //CopingOfStructRequired: 2
    }

    //private int Trasform(int index) => index != 0 ? -index - 2 : 0;

    internal void Print()
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append(_evaluationInfo.ToString());

        for (int i = 0; i < _flagLinks.Count; ++i)
        {
            if (_flagLinks[i] != -1)
                stringBuilder.Append("  ")
                             .Append(_evaluations[i].ToString())
                             .Append(_flags![_flagLinks[i]].ToString());
        }

        Console.WriteLine(stringBuilder.ToString());
    }


    private void UpdateErrorStatus(IncomplianceSeverity severity)
    {
        switch (severity)
        {
            case IncomplianceSeverity.Error:
            case IncomplianceSeverity.Fatal:
                HasErrors = true;
                break;
        }
    }
}