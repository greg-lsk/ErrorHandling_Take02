namespace ErrorHandling.Reporting.Formatting;

internal static class SeverityPrefix
{
    private static readonly char[] _alert = new[] { ' ', '|', '-', '[', 'a', 'l', 'e', 'r', 't', ']', ':' };
    private static readonly char[] _error = new[] { ' ', '|', '-', '[', 'e', 'r', 'r', 'o', 'r', ']', ':' };

    internal static ReadOnlySpan<char> GetSpan(IncomplianceSeverity severity) => severity switch
    {
        IncomplianceSeverity.Alert => _alert.AsSpan(),
        IncomplianceSeverity.Error => _error.AsSpan()
    };

    internal static ReadOnlyMemory<char> GetMemory(IncomplianceSeverity severity) => severity switch
    {
        IncomplianceSeverity.Alert => _alert.AsMemory(),
        IncomplianceSeverity.Error => _error.AsMemory()
    };
}