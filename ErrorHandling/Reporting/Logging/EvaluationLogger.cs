using ErrorHandling.Reporting.Formatting;
using Microsoft.Extensions.Logging;


namespace ErrorHandling.Reporting.Logging;

internal static class EvaluationLogger
{
    private static ILoggerFactory? _loggerFactory;
    private static readonly Dictionary<Type, ILogger> _loggers = new();

    internal static int ProviderIndent { get; private set; }


    internal static void Configure(LogConfig? config)
    {
        if (config is not null)
        {
            (_loggerFactory, ProviderIndent) = config();
            FlagPrefix.Create();
            return;
        }

        ProviderIndent = 6;
        FlagPrefix.Create();
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