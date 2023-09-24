using ErrorHandling.Public;


namespace ErrorHandling.Core.ErrorReporting;

internal class ReportCollection
{
    private readonly List<ReportIndex> _printIndexer;

    private readonly EvaluationReport _evaluationInfo;
    private List<EvaluatorReport>? _evaluations;
    private List<FlagReport>? _flags;

    internal bool HasErrors;


    internal ReportCollection(int collectionIndex,
                              string callerFilePath,
                              string callerMethodName,
                              int callerLineNumber)
    {
        _printIndexer = new() { new(collectionIndex, -1, -1) };
        _evaluationInfo = new(callerFilePath, callerMethodName, callerLineNumber);
    }


    internal void Insert(ref ReportIndex index, int callerLineNumber)
    { 
        if (index.evaluatorIndex >= 0)
        {
            _evaluations!.Add( new(callerLineNumber) );
            ++index.evaluatorIndex;
            return;
        }

        index.evaluatorIndex = 0;
        _evaluations = new() { new(callerLineNumber) };

        _printIndexer.Add( index.Copy() );
    }

    internal void Insert(ref ReportIndex index, Enum flag, IncomplianceSeverity severity)
    {
        if (index.flagIndex >= 0)
        {
            _flags!.Add( new(flag, severity) );
            ++index.flagIndex;
            return;
        }

        index.flagIndex = 0;
        _flags = new() { new(flag, severity) };

        _printIndexer.Add( index.Copy() );
    
        switch (severity)
        {
            case IncomplianceSeverity.Error:
            case IncomplianceSeverity.Fatal:
                HasErrors = true;
                break;
        }
    }

    internal void Print()
    {
        Console.WriteLine( _evaluationInfo.ToString() );
        PrintEvaluations();
        PrintFlags();
    }

    private void PrintEvaluations()
    {
        if (_evaluations is null)
            return;

        foreach (var evaluation in _evaluations)
            Console.WriteLine(evaluation.ToString());
    }

    private void PrintFlags()
    {
        if (_flags is null)
            return;

        foreach (var flag in _flags)
            Console.WriteLine(flag.ToString());
    }
}