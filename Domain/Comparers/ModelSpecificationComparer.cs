using Domain.Equality;
using Domain.ValueObjects;
using Domain.Comparers.EquityDelegates;


namespace Domain.Comparers;

public class ModelSpecificationComparer
{
    public static EqualityComparer<ModelSpecifications> ForValue =>
        Equity.Comparer(ModelSpecificationEquity.ByValue,
                        ModelSpecificationEquity.ValueHash);
}