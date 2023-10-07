using ErrorHandling.Reporting.Logging;
using Microsoft.Extensions.Logging;


namespace ErrorHandling;

public delegate (ILoggerFactory providerForwarder, int providerIndent) LogConfig();

public class EvaluationConfig
{
    public EvaluationConfig Logging(LogConfig logConfig = null!)
    { 
        EvaluationLogger.Configure(logConfig);
        return this;
    }
}