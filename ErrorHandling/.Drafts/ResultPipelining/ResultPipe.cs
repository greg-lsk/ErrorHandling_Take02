using ErrorHandling.ResultUtilities;


namespace ErrorHandling.Drafts.ResultPipelining;

public delegate void ResultPipeAction();
public delegate TResult ResultValueAssigner<TResult>(); 

public class ResultPipe
{
    private EvaluationState _state;
    private bool _operationSeized = false;
    

    public static ResultPipe Initialize()
    {
        var pipeline = new ResultPipe();
        return pipeline;
    }


    public ResultPipe CheckPrecondition<T>(T arg, Evaluation<T> ev)
    {
        if (_operationSeized) return this;

        if (ev.Invoke(arg, in _state)) return this;

        _operationSeized = true;
        return this;
    }

    public Result<TSubject> Execute<TSubject>(ResultValueAssigner<TSubject> assigner)
    {
        if (_operationSeized) return new Result<TSubject>();

        var subject = assigner.Invoke();
        return new Result<TSubject>(subject);
    }

    public VoidResult Execute(ResultPipeAction action)
    {
        if (_operationSeized) return new VoidResult();

        action.Invoke();
        return new VoidResult();
    }
}