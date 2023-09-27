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

        CurrentReport.LogIncompliance(ref _reportIndex, incompliance.Flag, incompliance.Severity);

        return this;
    }
}