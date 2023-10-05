using BenchmarkDotNet.Attributes;

using ErrorHandling.Benchmark.Utilities;
using ErrorHandling.Reporting.Collections;

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

    [Benchmark]
    public string StringReturn()
    {
        return flagCollection.LogString();
    }

    [Benchmark]
    public string SpanReturn()
    {
        return flagCollection.FlagCollectionPart();
    }
}