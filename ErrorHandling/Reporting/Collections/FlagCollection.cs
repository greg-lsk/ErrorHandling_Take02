using System.Text;
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

    public override readonly string ToString()
    {
        StringBuilder stringBuilder = new();

        stringBuilder.Append(_report.ToString())
                     .Append('\n');

        if (_reportList is null)
            return stringBuilder.ToString();

        for (int i = 0; i < _reportList.Count; ++i)
            stringBuilder.Append(_reportList[i].ToString());

        stringBuilder.Append('\n');

        return stringBuilder.ToString();
    }
}