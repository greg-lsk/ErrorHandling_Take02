using ErrorHandling.Reporting.CallStackInfo;
using ErrorHandling.Reporting.Collections;


namespace ErrorHandling.Reporting;

internal struct ReportIndex
{
    internal int reportLink;
    internal int evaluationLink;


    public ReportIndex()
    {
        reportLink = 0;
        evaluationLink = 0;
    }
}