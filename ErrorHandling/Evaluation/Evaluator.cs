using ErrorHandling.Reporting;
using System.Runtime.CompilerServices;


namespace ErrorHandling.Evaluation;

public partial class Evaluator<TSubject>
{
    private readonly Evaluation _evaluation;

    private TSubject? _subject;
    
    private bool _operationSeized;
    private AttachingBehaviour _attachingBehaviour;

    private ReportIndex _reportIndex;
    private EvaluationReport Report => _evaluation.Report;

    private bool AbortExamination 
        => _attachingBehaviour == AttachingBehaviour.OnErrorStop 
        && Report.HasErrors;


    internal Evaluator(TSubject? subject,
                       int callerLineNumber,
                       Evaluation evaluation)
    {
        _attachingBehaviour = AttachingBehaviour.OnErrorStop;

        _evaluation = evaluation;
        _reportIndex = new();

        Report.Insert(ref _reportIndex, callerLineNumber);

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
        Report.Insert(ref _reportIndex, callerLineNumber);

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

    public Evaluator<TSubject> Examine(in IncomplianceRecord<TSubject> incompliance)
    {
        if (_operationSeized) return this;

        if (AbortExamination) return this;

        if (!incompliance.AppliesTo(_subject!)) return this;

        if (incompliance.Severity == IncomplianceSeverity.Fatal) 
            _operationSeized = true;

        Report.Insert(ref _reportIndex, incompliance.Flag, incompliance.Severity);

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

    private void NullDetected()
    {      
        _operationSeized = true;
        Report.Insert(ref _reportIndex, UniversalFlags.NullDetected, IncomplianceSeverity.Fatal);
    }
    private void ResetState()
    { 
        _operationSeized = false;
        _reportIndex.evaluationIndex = 0;
        _attachingBehaviour = AttachingBehaviour.OnErrorStop;
    }
}