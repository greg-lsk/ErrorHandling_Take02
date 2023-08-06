using ErrorHandling.Core;


namespace ConsoleApp.SupervisorExtensions;

public static class SupervisorExtensions
{
    public static ref readonly ErrorHandler<TSubject> Check<TSubject, T1>(
        this Supervisor<TSubject> supervisor,
        Func<TSubject, T1, bool> incompliance, T1 param)
    {
        if (supervisor.InvocationBypass)
        {
            supervisor.AttachmentBypass = true;
            return ref supervisor.ErrorHandler;
        }

        supervisor.AttachmentBypass = !incompliance.Invoke(supervisor.Subject!, param);
        return ref supervisor.ErrorHandler;
    }
}