using ErrorHandling.ResultUtilities;
using ErrorHandling.Drafts.PipelineTemplates.Abstractions;


namespace ErrorHandling.Drafts.PipelineTemplates;

internal class ResultPipeTemplate00<TSubject> : IPipeBuilder
{
    private readonly Func<TSubject> _pipeDelegate;

    protected ResultPipeTemplate00(Func<TSubject> pipeDelegate) 
    {
        _pipeDelegate = pipeDelegate;
    }

    public Delegate ConstructPipe() =>
    () =>
    {
        var subject = _pipeDelegate.Invoke();

        return new Result<TSubject>(subject);
    };
}