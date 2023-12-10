using ErrorHandling.ResultUtilities;

namespace ErrorHandling;

public readonly partial struct EvaluationState
{
    public VoidResult YieldVoid<T1>(T1 param01, Action<T1> yieldAction)
    {
        if (Report.HasErrors) return Void();

        yieldAction.Invoke(param01);
        return new();
    }

    public VoidResult YieldVoid<T1, T2>(T1 param01, T2 param02, Action<T1, T2> yieldAction)
    {
        if (Report.HasErrors) return Void();

        yieldAction.Invoke(param01, param02);
        return new();
    }

    public VoidResult YieldVoid<T1, T2, T3>(T1 param01,T2 param02, T3 param03,
                                            Action<T1, T2, T3> yieldAction)
    {
        if (Report.HasErrors) return Void();

        yieldAction.Invoke(param01, param02, param03);
        return new();
    }

    public Result<TResult> YieldResult<TResult, T1>(T1 param01, Func<T1, TResult> yieldDelegate)
    {
        if (Report.HasErrors) return Result<TResult>();

        return new(yieldDelegate.Invoke(param01));
    }

    public Result<TResult> YieldResult<TResult, T1, T2>(T1 param01, T2 param02, 
                                                        Func<T1, T2, TResult> yieldDelegate)
    {
        if (Report.HasErrors) return Result<TResult>();

        return new(yieldDelegate.Invoke(param01, param02));
    }

    public Result<TResult> YieldResult<TResult, T1, T2, T3>(T1 param01, T2 param02, T3 param03,
                                                            Func<T1, T2, T3, TResult> yieldDelegate)
    {
        if (Report.HasErrors) return Result<TResult>();

        return new(yieldDelegate.Invoke(param01, param02, param03));
    }
}