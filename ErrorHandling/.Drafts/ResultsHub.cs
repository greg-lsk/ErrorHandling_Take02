namespace ErrorHandling.Drafts;

internal struct ResultsHub
{
    internal bool preconditionsMet = true;


    public ResultsHub() {}


    internal ResultsHub Invoke<T>(Evaluation<T>? precondition,
                                  T arg,
                                  in EvaluationState state)
    {
        if (!preconditionsMet) return this;
        if (precondition is null) return this;

        preconditionsMet = precondition.Invoke(arg, in state);

        return this;
    }
}