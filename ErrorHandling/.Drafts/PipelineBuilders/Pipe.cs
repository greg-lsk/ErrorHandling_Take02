using ErrorHandling.Drafts.PipelineBuilders.VoidPipeBuilders;
using ErrorHandling.ResultUtilities;


namespace ErrorHandling.Drafts.PipelineBuilders;

public static class Pipe
{
    public static ResultTypeSetter<TSubject> ForResult<TSubject>() => new();

    public static VoidPipeBuilderArgsThree<T1, T2, T3> WithParamTypes<T1, T2, T3>() => new();
}

public class ResultPipe
{
    private EvaluationState _state;
    private bool _operationSeized = false;


    public static ResultPipe Init()
    {
        var pipeline = new ResultPipe();
        return pipeline;
    }


    public ResultPipe Precondition<T>(T arg, Evaluation<T> ev)
    {
        if (_operationSeized) return this;

        if(ev.Invoke(arg, in _state)) return this;

        _operationSeized = true;
        return this;
    }

    public Result<TSubject> ForAction<TSubject>(Func<TSubject> func)
    {
        if (_operationSeized) return new Result<TSubject>();

        var subject = func.Invoke();
        return new Result<TSubject>(subject);
    }

    public VoidResult ForAction(Action func)
    {
        if (_operationSeized) return new VoidResult();

        func.Invoke();
        return new VoidResult();
    }
}