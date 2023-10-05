namespace ErrorHandling.Evaluating;

public partial class Evaluator<TSubject>
{
    public Evaluator<TSubject> Examine<T1>(
        in IncomplianceRecord<TSubject, T1> incompliance,
        T1 param)
    {
        if (_operationSeized) return this;

        if (AbortExamination) return this;

        if (!incompliance.AppliesTo(_subject!, param)) return this;

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
}