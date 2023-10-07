namespace ErrorHandling.Reporting.Formatting;

internal static class SubjectPrefix
{
    private static readonly char[] _prefix = { '[', 'S', 'u', 'b', 'j', 'e', 'c', 't', ']', ':', ' ' };

    internal static int Length => _prefix.Length;
    internal static ReadOnlySpan<char> SpanView => _prefix.AsSpan();
    internal static ReadOnlyMemory<char> MemoryView => _prefix.AsMemory();
}