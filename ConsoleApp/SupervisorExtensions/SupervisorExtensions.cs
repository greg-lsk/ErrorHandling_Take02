namespace ConsoleApp.SupervisorExtensions;

public static class SupervisorExtensions
{
/*    public static ref readonly FlagAttacher<TSubject> Check<TSubject, T1>(
        this Supervisor<TSubject> supervisor,
        Func<TSubject, T1, bool> incompliance, T1 param)
    {
        if (supervisor.InvocationBypass)
        {
            supervisor.AttachmentBypass = true;
            return ref supervisor.FlagAttacher;
        }

        supervisor.AttachmentBypass = !incompliance.Invoke(supervisor.Subject!, param);
        return ref supervisor.FlagAttacher;
    }*/
}