using System.Runtime.CompilerServices;

using ErrorHandling.Public;
using ErrorHandling.Core.ErrorReporting;


namespace ErrorHandling.Core.Evaluation;

public partial class Evaluator<TSubject>
{
    private TSubject? _subject;

    private ReportIndex _reportIndex;
    private readonly ReportCollection _report;
    
    private bool _operationSeized;
    private AttachingBehaviour _attachingBehaviour;


    internal Evaluator(TSubject? subject,
                      ReportCollection report,
                      int callerLineNumber)
    {
        _attachingBehaviour = AttachingBehaviour.OnErrorStop;

        _report = report;
        _reportIndex = new();

        _report.Insert(ref _reportIndex, callerLineNumber);

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
        ResetState();
        _report.Insert(ref _reportIndex, callerLineNumber);

        if (subject is null)
        {
            NullAssignmentAction();
            return this;
        }

        _subject = subject;
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

        if (_attachingBehaviour == AttachingBehaviour.OnErrorStop && _report.HasErrors)
            return this;

        if (!incompliance.AppliesTo(_subject!))
            return this;

        if (incompliance.Severity == IncomplianceSeverity.Fatal)
            _operationSeized = true;

        _report.Insert(ref _reportIndex, incompliance.Flag, incompliance.Severity);

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

    public void YieldResult<TEntity>(TEntity entity)
    {
        _report.Print();
    }

    internal void NullAssignmentAction()
    {      
        _operationSeized = true;
        _report.Insert(ref _reportIndex, UniversalFlags.NullDetected, IncomplianceSeverity.Fatal);
    }

    private void ResetState()
    {
        _operationSeized = false;

        _reportIndex.evaluatorIndex = -1;
        _reportIndex.flagIndex = -1;

        _attachingBehaviour = AttachingBehaviour.OnErrorStop;
    }
}