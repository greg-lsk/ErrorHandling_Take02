using ErrorHandling.Drafts.PipelineBuilders.GenericYield.Constructive;


namespace ErrorHandling.Drafts.PipelineBuilders;

public class ResultTypeSetter<TSubject>
{
    public ResultPipeBuilderArgsTwo<T1, T2, TSubject> WithParams<T1, T2>() => new();
}