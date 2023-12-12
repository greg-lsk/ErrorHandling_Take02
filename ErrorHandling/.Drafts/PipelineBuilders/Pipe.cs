using ErrorHandling.Drafts.PipelineBuilders.VoidPipeBuilders;


namespace ErrorHandling.Drafts.PipelineBuilders;

public static class Pipe
{
    public static ResultTypeSetter<TSubject> ForResult<TSubject>() => new();

    public static VoidPipeBuilderArgsThree<T1, T2, T3> WithParams<T1, T2, T3>() => new();
}