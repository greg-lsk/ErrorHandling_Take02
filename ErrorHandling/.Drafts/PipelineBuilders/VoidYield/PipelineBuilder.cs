using ErrorHandling.ResultUtilities;
using Void = ErrorHandling.Drafts.Pipelining.YieldDelegates.Void;


namespace ErrorHandling.Drafts.PipelineBuilders.VoidYield;

public class PipelineBuilder<T1, T2, T3>
{
    private Evaluation<T1>? _arg01Evaluation;
    private Evaluation<T2>? _arg02Evaluation;
    private Evaluation<T3>? _arg03Evaluation;

    private Action<T1, T2, T3>? _action;


    public PipelineBuilder<T1, T2, T3> EvaluateFirstArgument(Evaluation<T1>? evaluation = null)
    {
        _arg01Evaluation = evaluation;
        return this;
    }

    public PipelineBuilder<T1, T2, T3> EvaluateSecondArgument(Evaluation<T2>? evaluation = null)
    {
        _arg02Evaluation = evaluation;
        return this;
    }

    public PipelineBuilder<T1, T2, T3> EvaluateThirdArgument(Evaluation<T3>? evaluation = null)
    {
        _arg03Evaluation = evaluation;
        return this;
    }

    public PipelineBuilder<T1, T2, T3> ForAction(Action<T1, T2, T3> action)
    {
        _action = action;
        return this;
    }

    public Void.Yield<T1, T2, T3> Build() =>
    (T1 arg01, T2 arg02, T3 arg03) =>
    {
        var state = EvaluationState.Init<T1>();

        if (!_arg01Evaluation.Invoke(arg01, in state)) return new VoidResult();

        if (!_arg02Evaluation.Invoke(arg02, in state)) return new VoidResult();

        if (!_arg03Evaluation.Invoke(arg03, in state)) return new VoidResult();

        _action.Invoke(arg01,arg02, arg03);

        return new VoidResult();
    };

}