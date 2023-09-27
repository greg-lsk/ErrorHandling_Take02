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

    internal bool HasErrors => _flags is not null;


    internal EvaluationReport(string callerFilePath,
                              string callerMethodName,
                              int callerLineNumber)
    {
        _evaluationInfo = new(callerFilePath, callerMethodName, callerLineNumber);
        _flagLinks = new() { };
        _evaluations = new();
    }


    internal void LogEvaluation(ref ReportIndex index, int lineNumber)
    {
        _flagLinks.Add(-1);

        _evaluations.Add(new(lineNumber));

        ReportSynchronizer.UpdateEvaluationLink(ref index, _evaluations);
    }

    internal void LogIncompliance(ref ReportIndex index, Enum flag, IncomplianceSeverity severity)
    {
        _flagLinks[index.evaluationLink] = index.evaluationLink;
        
        if (_flags is null)
        {
            _flags = new() { new(flag, severity) };
            return;
        }

        if (index.evaluationLink < _flags.Count)
        {
            var flags = _flags[index.evaluationLink];
            flags.Add(flag, severity);
            _flags[index.evaluationLink] = flags;
            return;
        }

        _flags.Add( new(flag, severity) );
    }

    internal void LogExternal(ref ReportIndex index, int lineNumber, int collectionIndex)
    {
        _flagLinks.Add(ReportSynchronizer.Transform(collectionIndex));

        _evaluations.Add(new(lineNumber));

        ReportSynchronizer.UpdateEvaluationLink(ref index, _evaluations);
    }

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
}