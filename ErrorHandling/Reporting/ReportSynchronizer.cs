using ErrorHandling.Reporting.CallStackInfo;
using ErrorHandling.Reporting.Collections;


namespace ErrorHandling.Reporting;

internal static class ReportSynchronizer
{
    internal static int MergeReports(ReportCollection collection01,
                                     ReportCollection collection02)
    {
        return collection01.Append(collection02);
    }

    internal static int Transform(int index) => index != 0 ? -index - 1 : 0;

    internal static void UpdateEvaluationLink(ref ReportIndex index,
                                              List<EvaluatorInfo> evaluation)
    {
        index.evaluationLink = evaluation.Count - 1;
    }
}