namespace ErrorHandling.Reporting;

internal struct ReportIndex
{
    internal int reportIndex;
    internal int evaluationIndex;


    public ReportIndex()
    {
        reportIndex = -1;
        evaluationIndex = -1;
    }

    internal ReportIndex(int collectionIndex, int evaluatorIndex)
    {
        this.reportIndex = collectionIndex;
        this.evaluationIndex = evaluatorIndex;
    }
}