using ErrorHandling.Drafts.Pipelining;
using ErrorHandling.Drafts.PipelineTemplates;


namespace ErrorHandling.Drafts.PipelineBuilders.ResultPipeBuilders;

public ref struct ResultPipeBuilder02<T1, T2, TSubject>
{
    private Evaluation<T1>? _arg01Evaluation;
    private Evaluation<T2>? _arg02Evaluation;

    private Func<T1, T2, TSubject>? _pipeDelegate;


    public ResultPipeBuilder02<T1, T2, TSubject> GuardFirstArgument(Evaluation<T1> evaluation)
    {
        _arg01Evaluation = evaluation;
        return this;
    }

    public ResultPipeBuilder02<T1, T2, TSubject> GuardSecondArgument(Evaluation<T2> evaluation)
    {
        _arg02Evaluation = evaluation;
        return this;
    }

    public ResultPipeBuilder02<T1, T2, TSubject> ForAction(Func<T1, T2, TSubject> action)
    {
        _pipeDelegate = action;
        return this;
    }

    public readonly ResultPipe<T1, T2, TSubject> Build()
    {
        if( _pipeDelegate is null )
        {
            throw new InvalidOperationException("a pipeline method must be provided");
        }
        else
        {
            var template = new ResultPipeTemplate02<T1, T2, TSubject>(_pipeDelegate,
                                                                      _arg01Evaluation,
                                                                      _arg02Evaluation);

            return (template.ConstructPipe() as ResultPipe<T1, T2, TSubject>)!;
        }        
    }
}