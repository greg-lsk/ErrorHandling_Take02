using System;
using BenchmarkDotNet.Attributes;

using ErrorHandling.Benchmark.Utilities;
using ErrorHandling.Reporting.CallStackInfo;


namespace ErrorHandling.Benchmark.LogMessageBuilding;

[MemoryDiagnoser]
/// <summary>
/// Notice: To run the benchmark, please switch to "optimize-error-message-construction" branch 
/// </summary>
public class FlagInfoBuilding
{
    FlagInfo flagInfo = new(Mock.FlagPlaceholder, IncomplianceSeverity.Error);

    [Benchmark(Baseline = true)]
    public string StringConcatReturn()
    {
        return flagInfo.ToString();
    }

    [Benchmark]
    public Span<char> SpanReturn()
    {
        return flagInfo.SpanView;
    }

    [Benchmark]
    public Memory<char> MemoryReturn()
    {
        return flagInfo.MemoryView;
    }
}