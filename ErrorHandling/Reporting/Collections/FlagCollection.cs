using ErrorHandling.Reporting.CallStackInfo;


namespace ErrorHandling.Reporting.Collections;

internal struct FlagCollection
{
    private readonly FlagInfo _report;
    private List<FlagInfo>? _reportList;

    internal readonly int Count => _reportList is null ? 1 : _reportList.Count + 1;

    internal readonly FlagInfo this[int index] => index == 0 ? _report : _reportList[index - 1];

    internal FlagCollection(Enum flag, IncomplianceSeverity severity)
    {
        _report = new(flag, severity);
    }


    internal void Add(Enum flag, IncomplianceSeverity severity)
    {
        if (_reportList is not null)
        {
            _reportList.Add(new(flag, severity));
            return;
        }

        _reportList = new() { new(flag, severity) };
    }

    internal readonly string StringConcat()
    {
        var returnValue = "\n      " + _report.ToString();

        if (_reportList is null) return returnValue;

        foreach(var flagInfo in _reportList)
            returnValue += "\n      " + flagInfo.ToString();
        
        return returnValue;
    }

    internal readonly string SpanStringReturn()
    {
        Span<char> flagCollectionView = _report.SpanView;

        return flagCollectionView.ToString();        
    }

    internal readonly string MemoryStringReturn()
    {
        int allocSize;
        var memoryBuffer = new Memory<char>[Count];

        memoryBuffer[0] = _report.MemoryView;
        allocSize = memoryBuffer[0].Length;

        for (int i = 0; i < Count - 1; ++i)
        {
            memoryBuffer[i + 1] = _reportList[i].MemoryView;
            allocSize += memoryBuffer[i + 1].Length;
        }

        Memory<char> final = new char[allocSize];
        memoryBuffer[0].CopyTo(final);
        int addNextTo = memoryBuffer[0].Length;

        for (int i=1; i<memoryBuffer.Length; ++i)
        {
            memoryBuffer[i].CopyTo(final[addNextTo..]);
            addNextTo += memoryBuffer[i].Length;
        }

        return final.ToString();
    }

    internal readonly Span<char> SpanReturn()
    {
        Span<char> flagCollectionView = _report.SpanView;

        return flagCollectionView;
    }

    internal readonly Memory<char> MemoryReturn()
    {
        int allocSize;
        var memoryBuffer = new Memory<char>[Count];
        var smth = memoryBuffer.AsSpan();

        memoryBuffer[0] = _report.MemoryView;
        allocSize = memoryBuffer[0].Length;

        for (int i = 0; i < Count - 1; ++i)
        {
            memoryBuffer[i + 1] = _reportList[i].MemoryView;
            allocSize += memoryBuffer[i + 1].Length;
        }

        Memory<char> final = new char[allocSize];
        memoryBuffer[0].CopyTo(final);
        int addNextTo = memoryBuffer[0].Length;

        for (int i = 1; i < memoryBuffer.Length; ++i)
        {
            memoryBuffer[i].CopyTo(final[addNextTo..]);
            addNextTo += memoryBuffer[i].Length;
        }

        return final;
    }

    internal readonly Memory<char>[] MemoryArrayReturn()
    {
        var memoryBuffer = new Memory<char>[Count];
        
        memoryBuffer[0] = _report.MemoryView;
        
        for (int i = 0; i < Count - 1; ++i)
            memoryBuffer[i + 1] = _reportList[i].MemoryView;

        return memoryBuffer;
    }
    internal readonly Span<Memory<char>> MemorySpanReturn()
    {
        var memoryBuffer = new Memory<char>[Count]; //array pooling???

        memoryBuffer[0] = _report.MemoryView;

        for (int i = 0; i < Count - 1; ++i)
            memoryBuffer[i + 1] = _reportList[i].MemoryView;

        return memoryBuffer.AsSpan();
    }
}