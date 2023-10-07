namespace ErrorHandling.Reporting.Formatting;

public static class FlagPrefix
{
    public static int loggerProviderIndent;
    private static char[]? _flagInfoPrefix;

    internal static int Length => loggerProviderIndent + 1;

    public static void Create()
    {
        _flagInfoPrefix = new char[loggerProviderIndent + 1];

        _flagInfoPrefix[0] = '\n';
        for (int i = 1; i < _flagInfoPrefix.Length; ++i)
            _flagInfoPrefix[i] = ' ';

    }

    internal static ReadOnlySpan<char> SpanView => _flagInfoPrefix.AsSpan();
    internal static ReadOnlyMemory<char> MemoryView => _flagInfoPrefix.AsMemory();
}