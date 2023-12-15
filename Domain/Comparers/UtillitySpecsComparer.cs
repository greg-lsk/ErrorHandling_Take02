using Domain.Equality;
using Domain.ValueObjects;
using Domain.Comparers.EquityDelegates;


namespace Domain.Comparers;

public class UtillitySpecsComparer
{
    public static EqualityComparer<UtillitySpecs> ForValue =>
        Equity.Comparer(UtillitySpecsEquity.ByValue,
                        UtillitySpecsEquity.ValueHash);
}