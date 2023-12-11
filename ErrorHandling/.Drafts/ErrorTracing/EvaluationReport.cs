namespace ErrorHandling.Drafts;

internal class EvaluationReport
{
    private object[]? _errors;
    private object[]? _warnings;

    internal bool YieldedError<TSubject>(TSubject subject, Evaluation<TSubject> evaluation)
    {
        if (_errors == null) return false;

        for (int i = 0; i < _errors.Length; ++i)
            if ((_errors[i] as Evaluation<TSubject>) == evaluation) return true;

        
        return false;
    }
}