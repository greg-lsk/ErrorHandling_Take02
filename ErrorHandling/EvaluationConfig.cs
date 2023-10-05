using ErrorHandling.Reporting.Logging;
using Microsoft.Extensions.Logging;


namespace ErrorHandling;

public delegate ILoggerFactory LogForwarding();
public class EvaluationConfig
{
    public static void Logging(LogForwarding logForwardingDelegate = null!)
    {
        if(logForwardingDelegate is not null) 
        {
            EvaluationLogger.Configure(logForwardingDelegate.Invoke());
            return;
        }

        EvaluationLogger.Configure();
    }
        

}