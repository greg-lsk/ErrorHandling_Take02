using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;
using ErrorHandling.Benchmark.Utilities;
using ErrorHandling.Reporting.CallStackInfo;
using System;


namespace ErrorHandling.Benchmark;

[MemoryDiagnoser]
public class LogStringBuilding
{
    FlagInfo flagInfo = new(Mock.FlagPlaceholder, IncomplianceSeverity.Error);

    [Benchmark]
    public string StringConcatination()
    {
        return flagInfo.ToString();
    }
}