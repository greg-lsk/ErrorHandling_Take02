using ErrorHandling.ResultUtilities;
using ErrorHandling.Drafts.PipelineTemplates.Abstractions;


namespace ErrorHandling.Drafts.PipelineTemplates;

internal class ResultPipeTemplate01<T1, TSubject> : IPipeBuilder
{
    private readonly Func<T1, TSubject> _pipeDelegate;

    private readonly Evaluation<T1> _arg01Evaluation;


    protected ResultPipeTemplate01(Func<T1, TSubject> pipeDelegate, Evaluation<T1> arg01Evaluation) 
    {
        _arg01Evaluation = arg01Evaluation;
        _pipeDelegate = pipeDelegate;
    }


    public Delegate ConstructPipe() =>
    (T1 arg01) =>
    {
        var state = EvaluationState.Init<TSubject>();

        bool success = true;

        if (_arg01Evaluation.Invoke(arg01, in state)) success = false;

        if(success)
        {
            var subject = _pipeDelegate!.Invoke(arg01);
            return new Result<TSubject>(subject);
        }

        return new Result<TSubject>();
    };
}