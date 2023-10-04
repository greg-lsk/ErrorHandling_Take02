using ErrorHandling.Reporting.CallStackInfo;


namespace ErrorHandling.Reporting.Collections;

internal struct FlagCollection
{
    private readonly FlagInfo _report;
    private List<FlagInfo>? _reportList;

    internal readonly int Count => _reportList is null ? 1 : _reportList.Count + 1;


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

    internal readonly string LogString()
    {
        var returnValue = "\n      " + _report.ToString();

        if (_reportList is null) return returnValue;

        foreach(var flagInfo in _reportList)
            returnValue += "\n      " + flagInfo.ToString();
        
        return returnValue;
    }
}