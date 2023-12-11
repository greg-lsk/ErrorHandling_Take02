using ErrorHandling.Drafts.PipelineBuilders.GenericYield.Constructive;


namespace ErrorHandling.Drafts.PipelineBuilders;

public static class CtorPipe
{
    public static PipeBuilder<T1, T2, T3> WithSignature<T1, T2, T3>() => new();
}