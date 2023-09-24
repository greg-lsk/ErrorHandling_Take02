namespace ErrorHandling.Core.ErrorReporting;

internal struct ReportIndex
{
    internal int collectionIndex;
    internal int evaluatorIndex;
    internal int flagIndex;


    public ReportIndex()
    {
        collectionIndex = -1;
        evaluatorIndex = -1;
        flagIndex = -1;
    }

    internal ReportIndex(int collectionIndex, int evaluatorIndex, int flagIndex)
    {
        this.collectionIndex = collectionIndex;
        this.evaluatorIndex = evaluatorIndex;
        this.flagIndex = flagIndex;
    }


    internal readonly ReportIndex Copy() => new(collectionIndex, evaluatorIndex, flagIndex);
}