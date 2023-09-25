namespace ErrorHandling.Reporting;

internal struct ReportIndex
{
    internal int reportIndex;
    internal int evaluationIndex;


    public ReportIndex()
    {
        reportIndex = 0;
        evaluationIndex = 0;
    }

    internal ReportIndex(int collectionIndex, int evaluatorIndex)
    {
        this.reportIndex = collectionIndex;
        this.evaluationIndex = evaluatorIndex;
    }
}