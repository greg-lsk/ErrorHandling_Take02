namespace ErrorHandling.Drafts.PipelineTemplates.Abstractions;

internal abstract class PipeTemplate
{
    protected readonly Delegate _pipeDelegate;

    protected PipeTemplate(Delegate pipeDelegate)
    {
        _pipeDelegate = pipeDelegate;
    }
}