using ErrorHandling.Reporting;


namespace ErrorHandling.Evaluating;

public partial class Evaluator<TSubject>
{
    private TSubject? _subject;
    private readonly Evaluation _evaluation;

    private bool _operationSeized;
    private AttachingBehaviour _attachingBehaviour;

    private int _reportLink;
    private EvaluationReport Report => _evaluation.Report;

    private bool ErrorsOccured => Report.EvaluationYieldedErrors(_reportLink);
    private bool AbortExamination => _attachingBehaviour == AttachingBehaviour.OnErrorStop
                                     && ErrorsOccured;


    internal Evaluator(TSubject? subject,
                       Evaluation evaluation)
    {
        _attachingBehaviour = AttachingBehaviour.OnErrorStop;

        _evaluation = evaluation;
        _reportLink = Report.NextLink;

        if (subject is null)
        {
            NullDetected();
            return;
        }

        _subject = subject;
    }


    public Evaluator<TSubject> Evaluate(TSubject? subject)
    {
        ResetState();
        _reportLink = Report.NextLink;

        if (subject is null)
        {
            NullDetected();
            return this;
        }

        _subject = subject;
        return this;
    }

    public Evaluator<TNewSubject> Evaluate<TNewSubject>(TNewSubject? subject)
    {
        return new(subject, _evaluation);
    }

    public ref readonly Evaluation Evaluate(Result<TSubject> result)
    {
        if (!result.Report.HasErrors) return ref _evaluation;

        Report.LogExternal(result.Report);

        return ref _evaluation;
    }

    public Evaluator<TSubject> Examine(in IncomplianceRecord<TSubject> incompliance)
    {
        if (_operationSeized) return this;

        if (AbortExamination) return this;

        if (!incompliance.AppliesTo(_subject!)) return this;

        if (incompliance.Severity == IncomplianceSeverity.Fatal) 
            _operationSeized = true;

        Console.WriteLine($"[{incompliance.Severity}]:{incompliance.Flag}");

        Report.LogIncompliance(
            reportLink: ref _reportLink,
            flag:       incompliance.Flag,
            severity:   incompliance.Severity);
        
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
        if (ErrorsOccured) Console.WriteLine($"{Report.StringRep()}\n{_evaluation.TraceInfo}");

        return Report.HasErrors 
            ? new Result<T>(Report)
            : new Result<T>(createDelegate.Invoke(), Report);
    }

    private void NullDetected()
    {
        _operationSeized = true;

        Report.LogIncompliance(
            reportLink: ref _reportLink,
            flag:       UniversalFlags.NullDetected,
            severity:   IncomplianceSeverity.Fatal);
    }
    private void ResetState()
    { 
        _operationSeized = false;
        _attachingBehaviour = AttachingBehaviour.OnErrorStop;
    }
}