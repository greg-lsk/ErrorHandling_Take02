using Microsoft.Extensions.Logging;


namespace ErrorHandling.Reporting.Logging;

public class EvaluationLogger
{
    private static ILoggerFactory? _loggerFactory;
    private readonly static Dictionary<Type, ILogger> _loggers = new();


    public static void Configure(ILoggerFactory loggerFactory) => _loggerFactory = loggerFactory;


    internal static ILogger Get<TCategory>()
    {
        if (_loggers.ContainsKey(typeof(TCategory))) return _loggers[typeof(TCategory)];


        var logger = _loggerFactory.CreateLogger<TCategory>();
        _loggers.Add(typeof(TCategory), logger);
                
        return logger;
    }
}