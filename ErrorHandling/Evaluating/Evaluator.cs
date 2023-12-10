using ErrorHandling.Reporting;


namespace ErrorHandling.Evaluating;

public partial class Evaluator<TSubject>
{
    private TSubject? _subject;

    private bool _operationSeized;
    private EvaluationBehavior _attachingBehaviour;

    private int _reportLink;
    private readonly EvaluationReport _report;

    private bool ErrorsOccured => _report.EvaluationYieldedErrors(_reportLink);
    private bool AbortExamination => _attachingBehaviour == EvaluationBehavior.OnErrorStop
                                     && ErrorsOccured;


    internal Evaluator(EvaluationReport report)
    {
        _report = report;
        _attachingBehaviour = EvaluationBehavior.OnErrorStop;
    }


    public Evaluator<TSubject> Evaluate(TSubject? subject,
                                        Action<Evaluator<TSubject>> evaluateAgainst,
                                        EvaluationBehavior evaluationBehaviour)
    {
        ResetState();

        _subject = subject;
        _reportLink = _report.NextLink;
        _attachingBehaviour = evaluationBehaviour;
        
        if (subject is null) NullDetected();
        else evaluateAgainst.Invoke(this);
        
        return this;
    }

    public Evaluator<TSubject> Evaluate(Action<Evaluator<TSubject>> evaluateAgainst,
                                        EvaluationBehavior evaluationBehaviour,
                                        params TSubject?[] subjects)
    {
        for(int i=0; i<subjects.Length; ++i)
            Evaluate(subjects[i], evaluateAgainst, evaluationBehaviour);
        
        return this;
    }

/*    public Evaluator<TSubject> Examine(in IncomplianceRecord<TSubject> incompliance)
    {
        if (_operationSeized) return this;

        if (AbortExamination) return this;

        if (!incompliance.AppliesTo(_subject!)) return this;

        if (incompliance.Severity == IncomplianceSeverity.Fatal) 
            _operationSeized = true;

        UpdateReport(incompliance.Flag, incompliance.Severity);

        return this;
    }*/


    private void NullDetected()
    {
        _operationSeized = true;
        UpdateReport(UniversalFlags.NullDetected, IncomplianceSeverity.Fatal);
    }

    private void ResetState()
    { 
        _operationSeized = false;
    }

    private void UpdateReport(Enum incomplianceFlag, IncomplianceSeverity severity)
    {
        _report.RegisterFlag(ref _reportLink, incomplianceFlag, severity);
        _report.TryRegisterSubjectInfo(ref _reportLink, _subject is not null ? $"{_subject}" : "null");
    }
}