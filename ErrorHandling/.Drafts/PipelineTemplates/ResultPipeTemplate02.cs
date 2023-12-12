using ErrorHandling.ResultUtilities;
using ErrorHandling.Drafts.PipelineTemplates.Abstractions;


namespace ErrorHandling.Drafts.PipelineTemplates;

internal class ResultPipeTemplate02<T1, T2, TSubject> : IPipeBuilder
{
    private readonly Func<T1, T2, TSubject> _pipeDelegate;

    private readonly Evaluation<T1>? _arg01Evaluation;
    private readonly Evaluation<T2>? _arg02Evaluation;


    internal ResultPipeTemplate02(Func<T1, T2, TSubject> pipeDelegate,
                                Evaluation<T1>? arg01Evaluation,
                                Evaluation<T2>? arg02Evaluation)
    {
        _pipeDelegate = pipeDelegate;
        _arg01Evaluation = arg01Evaluation;
        _arg02Evaluation = arg02Evaluation;
    }


    public Delegate ConstructPipe() =>
    (T1 arg01, T2 arg02) =>
    {
        var state = EvaluationState.Init<TSubject>();

        bool success = true;

        if (_arg01Evaluation.Invoke(arg01, in state)) success = false;

        if (_arg02Evaluation.Invoke(arg02, in state)) success = false;

        var subject = _pipeDelegate.Invoke(arg01, arg02);
        return new Result<TSubject>(subject);
    };
}