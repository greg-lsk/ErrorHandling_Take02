namespace ErrorHandling;

public class ResultPipe
{
    private readonly EvaluationState _state;
    private bool _operationSeized = false;


    public static ResultPipe Initialize()
    {
        var pipeline = new ResultPipe();
        return pipeline;
    }


    public ResultPipe CheckPrecondition<T>(T arg, Evaluation<T> evaluation)
    {
        if (_operationSeized) return this;

        if (evaluation.Invoke(arg, in _state)) return this;

        _operationSeized = true;
        return this;
    }

    public Result<T> Execute<T>(TypeReturnAction<T> action)
    {
        if (_operationSeized) return new Result<T>();

        var subject = action.Invoke();
        return new Result<T>(subject);
    }

    public VoidResult Execute(VoidReturnAction action)
    {
        if (_operationSeized) return new VoidResult();

        action.Invoke();
        return new VoidResult();
    }
}