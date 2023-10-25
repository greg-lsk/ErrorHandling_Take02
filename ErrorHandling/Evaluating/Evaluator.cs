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


    internal Evaluator(EvaluationReport report)
    {
        _report = report;
        _attachingBehaviour = AttachingBehaviour.OnErrorStop;
    }


    public Evaluator<TSubject> Evaluate(TSubject? subject,
                                        Action<Evaluator<TSubject>> evaluateAgainst,
                                        AttachingBehaviour evaluationBehaviour)
    {
        ResetState();
        _attachingBehaviour = evaluationBehaviour;
        _reportLink = _report.NextLink;

        if (subject is null)
        {
            NullDetected();
        }
        else
        {
            _subject = subject;
            evaluateAgainst.Invoke(this);
        }

        return this;
    }

    public Evaluator<TSubject> Evaluate(Action<Evaluator<TSubject>> evaluateAgainst,
                                        AttachingBehaviour evaluationBehaviour,
                                        params TSubject?[] subjects)
    {
        for(int i=0; i<subjects.Length; ++i)
            Evaluate(subjects[i], evaluateAgainst, evaluationBehaviour);
        
        return this;
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
    }
}