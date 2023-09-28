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

        Console.WriteLine($"[{incompliance.Severity}]:{incompliance.Flag}");
        Report.LogIncompliance(
            reportLink: ref _reportLink,
            flag:       incompliance.Flag,
            severity:   incompliance.Severity);

        return this;
    }
}