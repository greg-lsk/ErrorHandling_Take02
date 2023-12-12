using ErrorHandling.Drafts.PipelineBuilders.ResultPipeBuilders;


namespace ErrorHandling.Drafts.PipelineBuilders;

public class ResultTypeSetter<TSubject>
{
    public ResultPipeBuilderArgsTwo<T1, T2, TSubject> WithParamTypes<T1, T2>() => new();
}