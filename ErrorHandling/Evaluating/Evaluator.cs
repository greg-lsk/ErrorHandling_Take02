using ErrorHandling.Reporting;
using System.Runtime.CompilerServices;


namespace ErrorHandling.Evaluating;

public partial class Evaluator<TSubject>
{
    private TSubject? _subject;
    private ReportIndex _reportIndex;
    private readonly Evaluation _evaluation;

    private bool _operationSeized;
    private AttachingBehaviour _attachingBehaviour;

    private EvaluationReport CurrentReport 
        => _evaluation.Reports[_reportIndex.reportLink];

    private bool AbortExamination 
        => _attachingBehaviour == AttachingBehaviour.OnErrorStop 
        && CurrentReport.HasErrors;


    internal Evaluator(TSubject? subject,
                       int callerLineNumber,
                       Evaluation evaluation)
    {
        _attachingBehaviour = AttachingBehaviour.OnErrorStop;

        _evaluation = evaluation;
        _reportIndex = new();

        CurrentReport.LogEvaluation(
            index:      ref _reportIndex,
            lineNumber: callerLineNumber);

        if (subject is null)
        {
            NullDetected();
            return;
        }

        _subject = subject;
    }


    public Evaluator<TSubject> Evaluate(TSubject? subject,
                                        [CallerLineNumber] int callerLineNumber = 0)
    {
        ResetState();

        CurrentReport.LogEvaluation(
            index:      ref _reportIndex,
            lineNumber: callerLineNumber);

        if (subject is null)
        {
            NullDetected();
            return this;
        }

        _subject = subject;
        return this;
    }

    public Evaluator<TNewSubject> Evaluate<TNewSubject>(TNewSubject? subject,
                                                        [CallerLineNumber] int callerLineNumber = 0)
    {
        return new(subject, callerLineNumber, _evaluation);
    }

    public Evaluation Evaluate(Result<TSubject> result,
                               [CallerLineNumber] int callerLineNumber = 0)
    {
        CurrentReport.LogExternal(
            index:           ref _reportIndex,
            lineNumber:      callerLineNumber,
            collectionIndex: ReportSynchronizer.MergeReports(_evaluation.Reports, result.Reports));

        return _evaluation;
    }

    public Evaluator<TSubject> Examine(in IncomplianceRecord<TSubject> incompliance)
    {
        if (_operationSeized) return this;

        if (AbortExamination) return this;

        if (!incompliance.AppliesTo(_subject!)) return this;

        if (incompliance.Severity == IncomplianceSeverity.Fatal) 
            _operationSeized = true;

        CurrentReport.LogIncompliance(
            index:    ref _reportIndex,
            flag:     incompliance.Flag,
            severity: incompliance.Severity);
        
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

    public ref readonly Evaluation Snooze() => ref _evaluation;

    public Result<T> YieldResult<T>(Func<T> createDelegate)
    {
        return CurrentReport.HasErrors 
            ? new Result<T>(_evaluation.Reports)
            : new Result<T>(createDelegate.Invoke(), _evaluation.Reports);
    }

    private void NullDetected()
    {      
        _operationSeized = true;

        CurrentReport.LogIncompliance(
            index:    ref _reportIndex,
            flag:     UniversalFlags.NullDetected,
            severity: IncomplianceSeverity.Fatal);
    }
    private void ResetState()
    { 
        _operationSeized = false;
        _attachingBehaviour = AttachingBehaviour.OnErrorStop;
    }
}