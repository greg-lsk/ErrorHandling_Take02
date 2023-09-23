using ErrorHandling.Core.ErrorReporting;
using ErrorHandling.Public;

namespace ErrorHandling.Core.Evaluation;

public partial class Evaluator<TSubject>
{
    public Evaluator<TSubject> Examine<T1>(
        in IncomplianceRecord<TSubject, T1> incompliance,
        T1 param)
    {
        if (_operationSeized)
            return this;

        if (_attachingBehaviour == AttachingBehaviour.OnErrorStop && _incomplianceOccured)
            return this;

        _incomplianceOccured = incompliance.AppliesTo(_subject!, param);
        if (!_incomplianceOccured)
            return this;

        if (incompliance.Severity == IncomplianceSeverity.Fatal)
            _operationSeized = true;

        Report.Add(new FlagReport(incompliance.Flag, incompliance.Severity), _addAt);

        return this;
    }
}