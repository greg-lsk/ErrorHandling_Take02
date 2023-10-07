namespace ErrorHandling.Reporting.Formatting;

internal static class SeverityPrefix
{
    private static readonly char[] _alert = new[] { ' ', '|', '-', '[', 'a', 'l', 'e', 'r', 't', ']', ':' };
    private static readonly char[] _error = new[] { ' ', '|', '-', '[', 'e', 'r', 'r', 'o', 'r', ']', ':' };
    private static readonly char[] _fatal = new[] { ' ', '|', '-', '[', 'f', 'a', 't', 'a', 'l', ']', ':' };

    internal static ReadOnlySpan<char> GetSpan(IncomplianceSeverity severity) => severity switch
    {
        IncomplianceSeverity.Alert => _alert.AsSpan(),
        IncomplianceSeverity.Error => _error.AsSpan(),
        IncomplianceSeverity.Fatal => _fatal.AsSpan()
    };

    internal static ReadOnlyMemory<char> GetMemory(IncomplianceSeverity severity) => severity switch
    {
        IncomplianceSeverity.Alert => _alert.AsMemory(),
        IncomplianceSeverity.Error => _error.AsMemory(),
        IncomplianceSeverity.Fatal => _fatal.AsMemory()
    };
}