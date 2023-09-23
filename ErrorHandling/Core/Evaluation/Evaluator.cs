using System.Runtime.CompilerServices;

using ErrorHandling.Public;
using ErrorHandling.Core.ErrorReporting;


namespace ErrorHandling.Core.Evaluation;

public partial class Evaluator<TSubject>
{
    private TSubject? _subject;

    private int _addAt;
    private readonly EvaluationReport _report;
    private ref readonly EvaluationReport Report => ref _report;
    
    private bool _operationSeized;
    private bool _incomplianceOccured;
    private AttachingBehaviour _attachingBehaviour;


    private Evaluator(TSubject? subject,
                      EvaluationReport report,
                      int callerLineNumber)
    {
        _attachingBehaviour = AttachingBehaviour.OnErrorStop;
        _report = report;

        var evReport = new EvaluatorReport(callerLineNumber);
        _report.Add(evReport, out _addAt);

        if (subject is null)
        {
            NullAssignmentAction();
            return;
        }

        _subject = subject;
    }
    internal Evaluator(TSubject? subject,
                       string callerFilePath,
                       string callerMemberName,
                       int callerLineNumber,
                       int callerLineNumber02)
    {
        _attachingBehaviour = AttachingBehaviour.OnErrorStop;
        _report = new(callerFilePath, callerMemberName, callerLineNumber);

        var report = new EvaluatorReport(callerLineNumber02);
        _report.Add(report, out _addAt);

        if (subject is null)
        {
            NullAssignmentAction();
            return;
        }

        _subject = subject;    
    }


    public Evaluator<TSubject> Evaluate(TSubject? subject,
                                        [CallerLineNumber] int callerLineNumber = 0)
    {
        var report = new EvaluatorReport(callerLineNumber);
        _report.Add(report, out _addAt);

        if (subject is null)
        {
            NullAssignmentAction();
            return this;
        }

        _subject = subject;
        ResetState();
        return this;
    }
    public Evaluator<TNewSubject> Evaluate<TNewSubject>(TNewSubject? subject,
                                                        [CallerLineNumber] int callerLineNumber = 0)
    {
        return new(subject, _report, callerLineNumber);
    }

    public Evaluator<TSubject> Examine(in IncomplianceRecord<TSubject> incompliance)
    {
        if (_operationSeized)
            return this;

        if (_attachingBehaviour == AttachingBehaviour.OnErrorStop && _incomplianceOccured)
            return this;

        _incomplianceOccured = incompliance.AppliesTo(_subject!);
        if (!_incomplianceOccured)
            return this;

        if (incompliance.Severity == IncomplianceSeverity.Fatal)
            _operationSeized = true;

        _report.Add(new FlagReport(incompliance.Flag, incompliance.Severity), _addAt);

        return this;
    }

    public Evaluator<TSubject> CaptureFirst()
    {
        _attachingBehaviour = AttachingBehaviour.OnErrorStop;
        return this;
    }

    public Evaluator<TSubject> CaptureAll()
    {
        _attachingBehaviour = AttachingBehaviour.Accumulative;
        return this;
    }

    public Result<TEntity> YieldResult<TEntity>(TEntity entity)
    {
        return new(entity, Report);
    }

    internal void NullAssignmentAction()
    {      
        _operationSeized = true;
        _report.Add(new FlagReport(UniversalFlags.NullDetected, IncomplianceSeverity.Fatal), _addAt);
    }

    private void ResetState()
    {
        _operationSeized = false;
        _incomplianceOccured = false;
        _attachingBehaviour = AttachingBehaviour.OnErrorStop;
    }
}