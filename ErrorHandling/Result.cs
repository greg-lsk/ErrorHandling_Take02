using ErrorHandling.Reporting.Collections;


namespace ErrorHandling;

public class Result<T>
{
    public T? Value { get; private set; }

    internal readonly ReportCollection Reports;


    internal Result(T value, ReportCollection reports)
    {
            Value = value;
            Reports = reports;
    }

    internal Result(ReportCollection reports)
    {
        Value = default;
        Reports = reports;
    }

    public void Print() => Reports.Print();
}