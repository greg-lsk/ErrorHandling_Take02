using ErrorHandling.ResultUtilities;
using Ctor = ErrorHandling.Drafts.Pipelining.YieldDelegates.Generic.Contsructive;


namespace ErrorHandling.Drafts.PipelineBuilders.GenericYield.Constructive;

public class PipelineBuilder<TSubject, T1, T2>
{
    private Evaluation<TSubject>? _subjectEvaluation;
    private Evaluation<T1>? _arg01Evaluation;
    private Evaluation<T2>? _arg02Evaluation;

    private Func<T1, T2, TSubject>? _middleAction;


    public PipelineBuilder<TSubject, T1, T2> EvaluateFirstArgument(Evaluation<T1> evaluation)
    {
        _arg01Evaluation = evaluation;
        return this;
    }

    public PipelineBuilder<TSubject, T1, T2> EvaluateSecondArgument(Evaluation<T2> evaluation)
    {
        _arg02Evaluation = evaluation;
        return this;
    }

    public PipelineBuilder<TSubject, T1, T2> ForAction(Func<T1, T2, TSubject> action)
    {
        _middleAction = action;
        return this;
    }

    public Ctor.Yield<TSubject, T1, T2> Build() =>
    (T1 arg01, T2 arg02) =>
    {
        var state = EvaluationState.Init<TSubject>();

        if (!_arg01Evaluation.Invoke(arg01, in state)) return new Result<TSubject>();

        if (!_arg02Evaluation.Invoke(arg02, in state)) return new Result<TSubject>();

        var subject = _middleAction.Invoke(arg01, arg02);

        return new Result<TSubject>(subject);
    };
}