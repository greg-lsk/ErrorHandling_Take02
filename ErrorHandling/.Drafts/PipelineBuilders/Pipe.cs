using ErrorHandling.Drafts.PipelineBuilders.VoidPipeBuilders;
using ErrorHandling.ResultUtilities;


namespace ErrorHandling.Drafts.PipelineBuilders;

public static class Pipe
{
    public static ResultTypeSetter<TSubject> ForResult<TSubject>() => new();

    public static VoidPipeBuilderArgsThree<T1, T2, T3> WithParamTypes<T1, T2, T3>() => new();
}