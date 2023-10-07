using BenchmarkDotNet.Attributes;
using ErrorHandling.Benchmark.Utilities;
using ErrorHandling.Reporting;

namespace ErrorHandling.Benchmark.LogMessageBuilding;

[MemoryDiagnoser]
public class EvaluationReportBuilding
{
    EvaluationReport Report = new();

    [Params(1, 10, 20)]
    public int FlagsCaptured;

    [Params(1, 5, 10)]
    public int SubjectsEvaluated;

    [GlobalSetup]
    public void Setup()
    {
        for(int i = 0; i<SubjectsEvaluated; ++i)
        {
            var reportLink = Report.NextLink;

            for(int j=0; j<FlagsCaptured; ++j)
            {
                Report.RegisterFlag(ref reportLink, Mock.FlagPlaceholder, IncomplianceSeverity.Error);
                Report.TryRegisterSubjectInfo(ref reportLink, "TestSubject");
            }

        }
    }

    [Benchmark]
    public string StringConcat() => Report.StringRep();

    [Benchmark]
    public string StringFromSpan() => Report.SpanReturnFromCollection();
}