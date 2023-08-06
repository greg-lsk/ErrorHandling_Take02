using ErrorHandling.Public;

namespace ErrorHandling.Core;

public readonly struct ErrorHandler<T>
{
    private readonly Supervisor<T> _supervisor;

    public ErrorHandler(Supervisor<T> supervisor) => _supervisor = supervisor;

    public readonly Supervisor<T> OnErrorAttach(Enum flag)
    {
        if (!_supervisor.AttachmentBypass)
        {
            ++_supervisor.ErrorsCaptured;
            _supervisor.Supervision.Flags.Add(flag);
        }

        return _supervisor;
    }
}

public class Supervisor<T>
{
    private SupervisionBehaviour _supervisorBehaviour;

    internal readonly Supervision Supervision;
    public ErrorHandler<T> ErrorHandler;

    private readonly bool _nullBypass;
    public bool AttachmentBypass;
    public bool InvocationBypass =>
        _nullBypass || (_supervisorBehaviour == SupervisionBehaviour.OnErrorStop && ErrorsCaptured > 0);

    public readonly T? Subject;
    internal int ErrorsCaptured = 0;

    internal Supervisor(Supervision supervision, T subject)
    {
        Supervision = supervision;

        Subject = subject is not null ? subject : default;

        _nullBypass = subject is null;
        _supervisorBehaviour = SupervisionBehaviour.OnErrorStop;
    }


    public Supervisor<T> IfNullAttach(Enum nullFlag)
    {
        if (_nullBypass)
            Supervision.Flags.Add(nullFlag);

        return this;
    }

    public ref readonly ErrorHandler<T> Check(Func<T, bool> incompliance)
    {
        if (InvocationBypass)
        {
            AttachmentBypass = true;
            return ref ErrorHandler;
        }

        AttachmentBypass = !incompliance.Invoke(Subject!);
        return ref ErrorHandler;
    }


    public Supervisor<T> CaptureFirst()
    {
        _supervisorBehaviour = SupervisionBehaviour.OnErrorStop;
        return this;
    }
    public Supervisor<T> CaptureAll()
    {
        _supervisorBehaviour = SupervisionBehaviour.Accumulative;
        return this;
    }

    public Supervisor<T1> Supervise<T1>(T1 param)
    {
        var supervisor = new Supervisor<T1>(Supervision, param);
        supervisor.CreateErrorHandler();
        return supervisor;
    }

    public Supervision Finalize() => Supervision;

    internal void CreateErrorHandler() => ErrorHandler = new(this);
}