using System.Runtime.CompilerServices;
using ErrorHandling.Public;


namespace ErrorHandling.Core;

internal enum SupervisionBehaviour
{
    Accumulative,
    OnErrorStop
}

public class Supervision
{
    private CallerInfo _callerInfo;
    internal readonly List<Enum> Flags = new();
    

    public static Supervision Init(
        [CallerFilePath] string callerFilePath = null!,
        [CallerMemberName] string callerMemberName = null!,
        [CallerLineNumber] int callerLineNumber = 0)
    {
        return new() { _callerInfo = new(callerFilePath, callerMemberName, callerLineNumber) };
    }


    public Supervisor<T> Supervise<T>(T param)
    {
        var supervisor = new Supervisor<T>(this, param);
        supervisor.CreateErrorHandler();
        return supervisor;
    }

    public IResult<T> YieldResult<T>() => new Result<T>(Flags, _callerInfo.ToString());    
}