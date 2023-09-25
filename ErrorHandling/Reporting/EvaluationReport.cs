using System.Text;
using ErrorHandling.Reporting.CallStackInfo;
using ErrorHandling.Reporting.Collections;

namespace ErrorHandling.Reporting;
internal class EvaluationReport
{
    private readonly EvaluationInfo _evaluationInfo;

    private readonly List<int> _printIndexer;
    private readonly List<EvaluatorInfo> _evaluations;

    private List<FlagCollection>? _flags;

    internal bool HasErrors;


    internal EvaluationReport(string callerFilePath,
                              string callerMethodName,
                              int callerLineNumber)
    {
        _printIndexer = new() { };
        _evaluationInfo = new(callerFilePath, callerMethodName, callerLineNumber);
        _evaluations = new();
    }


    internal void Insert(ref ReportIndex index, int callerLineNumber)
    {
        _evaluations.Add(new(callerLineNumber));
        index.evaluatorIndex = _evaluations.Count - 1;

        _printIndexer.Add(-1);
    }

    internal void Insert(ref ReportIndex index, Enum flag, IncomplianceSeverity severity)
    {
        _printIndexer[index.evaluatorIndex] = index.evaluatorIndex;
        UpdateErrorStatus(severity);

        if (_flags is null)
        {
            _flags = new() { new(flag, severity) };
            return;
        }

        //CopingOfStructRequired: 2             
        var flags = _flags[index.evaluatorIndex];
        flags.Add(flag, severity);
        _flags[index.evaluatorIndex] = flags;
        //CopingOfStructRequired: 2
    }

    //private int Trasform(int index) => index != 0 ? -index - 2 : 0;

    internal void Print()
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append(_evaluationInfo.ToString());

        for (int i = 0; i < _printIndexer.Count; ++i)
        {
            if (_printIndexer[i] != -1)
                stringBuilder.Append("  ")
                             .Append(_evaluations[i].ToString())
                             .Append(_flags![_printIndexer[i]].ToString());
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