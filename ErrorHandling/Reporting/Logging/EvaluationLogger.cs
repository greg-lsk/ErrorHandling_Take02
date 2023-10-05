using Microsoft.Extensions.Logging;


namespace ErrorHandling.Reporting.Logging;

internal class EvaluationLogger
{
    private static ILoggerFactory? _loggerFactory;
    private static readonly Dictionary<Type, ILogger> _loggers = new();


    internal static void Configure(ILoggerFactory loggerFactory = null!)
    {
        if (loggerFactory is not null)
        {
            _loggerFactory = loggerFactory;
            return;
        }

        _loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
    }


    internal static ILogger Get<TCategory>()
    {
        var key = typeof(TCategory);

        if (_loggers.ContainsKey(key)) return _loggers[key];

        var logger = _loggerFactory.CreateLogger<TCategory>();
        _loggers.Add(key, logger);
                
        return logger;
    }
}