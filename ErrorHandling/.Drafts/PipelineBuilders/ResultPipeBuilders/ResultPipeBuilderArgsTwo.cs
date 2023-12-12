using ErrorHandling.Drafts.Pipelining;
using ErrorHandling.ResultUtilities;


namespace ErrorHandling.Drafts.PipelineBuilders.GenericYield.Constructive;

public class ResultPipeBuilderArgsTwo<T1, T2, TSubject>
{
    private Evaluation<T1>? _arg01Evaluation;
    private Evaluation<T2>? _arg02Evaluation;

    private Func<T1, T2, TSubject>? _createDelegate;


    public ResultPipeBuilderArgsTwo<T1, T2, TSubject> GuardFirstArgument(Evaluation<T1> evaluation)
    {
        _arg01Evaluation = evaluation;
        return this;
    }

    public ResultPipeBuilderArgsTwo<T1, T2, TSubject> GuardSecondArgument(Evaluation<T2> evaluation)
    {
        _arg02Evaluation = evaluation;
        return this;
    }

    public ResultPipeBuilderArgsTwo<T1, T2, TSubject> ForAction(Func<T1, T2, TSubject> action)
    {
        _createDelegate = action;
        return this;
    }

    public ResultPipe<T1, T2, TSubject> Build() =>
    (T1 arg01, T2 arg02) =>
    {
        var state = EvaluationState.Init<TSubject>();

        if (!_arg01Evaluation.Invoke(arg01, in state)) return new Result<TSubject>();

        if (!_arg02Evaluation.Invoke(arg02, in state)) return new Result<TSubject>();

        var subject = _createDelegate.Invoke(arg01, arg02);

        return new Result<TSubject>(subject);
    };
}