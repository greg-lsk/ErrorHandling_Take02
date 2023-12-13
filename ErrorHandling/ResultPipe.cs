using System.Runtime.CompilerServices;


namespace ErrorHandling;

public class ResultPipe
{
    private readonly EvaluationState _state;
    private bool _operationSeized;


    private ResultPipe(string callerMemberName, int callerLineNumber)
    {
        _state = new(callerMemberName, callerLineNumber);
        _operationSeized = false;
    }

    public static ResultPipe Initialize(
        [CallerMemberName] string callerMemberName = null!,
        [CallerLineNumber] int callerLineNumber = 0)
    {
        var pipeline = new ResultPipe(callerMemberName, callerLineNumber);
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