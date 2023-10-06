using BenchmarkDotNet.Attributes;

using ErrorHandling.Benchmark.Utilities;
using ErrorHandling.Reporting.Collections;
using System;

namespace ErrorHandling.Benchmark.LogMessageBuilding;

[MemoryDiagnoser]
public class FlagCollectionBuilding
{
    FlagCollection flagCollection = new(Mock.FlagPlaceholder, IncomplianceSeverity.Error);

    [Params(1, 10, 20)]
    public int FlagsCaptured;

    [GlobalSetup]
    public void Setup()
    {
        if (FlagsCaptured == 1) return;

        for (int i = 1; i < FlagsCaptured; ++i)
            flagCollection.Add(Mock.FlagPlaceholder, IncomplianceSeverity.Error);
    }

    [Benchmark(Baseline = true)]
    public string StringConcat() => flagCollection.StringConcat();
    
    [Benchmark]
    public string SpanStringReturn() => flagCollection.SpanStringReturn();

    [Benchmark]
    public Span<char> SpanReturn() => flagCollection.SpanReturn();

    [Benchmark]
    public string MemoryStringReturn() => flagCollection.MemoryStringReturn();
    
    [Benchmark]
    public Memory<char> MemoryReturn() => flagCollection.MemoryReturn();

    [Benchmark]
    public Memory<char>[] MemoryArrayReturn() => flagCollection.MemoryArrayReturn();

    [Benchmark]
    public Span<Memory<char>> MemorySpanReturn() => flagCollection.MemorySpanReturn();
}