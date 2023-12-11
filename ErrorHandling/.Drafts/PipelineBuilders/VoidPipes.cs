using ErrorHandling.Drafts.PipelineBuilders.VoidYield;


namespace ErrorHandling.Drafts.PipelineBuilders;

public static class VoidPipes
{
    public static PipeBuilder<T1, T2, T3> WithSignature<T1, T2, T3>() => new();
}