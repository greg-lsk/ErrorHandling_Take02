using ErrorHandling.Reporting.Logging;


namespace ErrorHandling.Reporting.Formatting;

internal static class FlagPrefix
{
    private static char[]? _flagInfoPrefix;

    internal static int Length => EvaluationLogger.ProviderIndent + 1;

    internal static void Create()
    {
        _flagInfoPrefix = new char[EvaluationLogger.ProviderIndent + 1];

        _flagInfoPrefix[0] = '\n';
        for (int i = 1; i < _flagInfoPrefix.Length; ++i)
            _flagInfoPrefix[i] = ' ';

    }

    internal static ReadOnlySpan<char> SpanView => _flagInfoPrefix.AsSpan();
    internal static ReadOnlyMemory<char> MemoryView => _flagInfoPrefix.AsMemory();
}