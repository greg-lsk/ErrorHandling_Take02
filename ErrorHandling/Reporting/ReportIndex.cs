namespace ErrorHandling.Reporting;

internal struct ReportIndex
{
    internal int collectionIndex;
    internal int evaluatorIndex;


    public ReportIndex()
    {
        collectionIndex = -1;
        evaluatorIndex = -1;
    }

    internal ReportIndex(int collectionIndex, int evaluatorIndex)
    {
        this.collectionIndex = collectionIndex;
        this.evaluatorIndex = evaluatorIndex;
    }
}