using ErrorHandling.Reporting;


namespace ErrorHandling.Evaluating;

public partial class Evaluator<TSubject>
{
    private TSubject? _subject;

    private bool _operationSeized;
    private AttachingBehaviour _attachingBehaviour;

    private int _reportLink;
    private readonly EvaluationReport _report;

    private bool ErrorsOccured => _report.EvaluationYieldedErrors(_reportLink);
    private bool AbortExamination => _attachingBehaviour == AttachingBehaviour.OnErrorStop
                                     && ErrorsOccured;


    internal Evaluator(TSubject? subject,
                       EvaluationReport report)
    {
        _attachingBehaviour = AttachingBehaviour.OnErrorStop;

        _report = report;
        _reportLink = _report.NextLink;

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
        _reportLink = _report.NextLink;

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
        return new(subject, _report);
    }

    public Evaluator<TSubject> Examine(in IncomplianceRecord<TSubject> incompliance)
    {
        if (_operationSeized) return this;

        if (AbortExamination) return this;

        if (!incompliance.AppliesTo(_subject!)) return this;

        if (incompliance.Severity == IncomplianceSeverity.Fatal) 
            _operationSeized = true;

        _report.RegisterFlag(
            reportLink: ref _reportLink,
            flag:       incompliance.Flag,
            severity:   incompliance.Severity);

        _report.TryRegisterSubjectInfo(
            reportLink:  ref _reportLink, 
            subjectInfo: $"{_subject}");

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

    public Evaluator<TSubject> CaptureAll(Action<Evaluator<TSubject>> evaluationAction)
    {
        _attachingBehaviour = AttachingBehaviour.Accumulative;
        evaluationAction.Invoke(this);
        return this;
    }

    private void NullDetected()
    {
        _operationSeized = true;

        _report.RegisterFlag(
            reportLink: ref _reportLink,
            flag:       UniversalFlags.NullDetected,
            severity:   IncomplianceSeverity.Fatal);

        _report.TryRegisterSubjectInfo(
            reportLink: ref _reportLink,
            subjectInfo: "null");
    }
    private void ResetState()
    { 
        _operationSeized = false;
        _attachingBehaviour = AttachingBehaviour.OnErrorStop;
    }
}